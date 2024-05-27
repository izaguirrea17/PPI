using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PPIChallenge.Data;
using PPIChallenge.Dtos;
using PPIChallenge.DTOs;
using PPIChallenge.Models;
using System;
using System.Net;
using static PPIChallenge.Enums.Enums;

namespace PPIChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdenController : ControllerBase
    {
        private readonly ILogger<OrdenController> _logger;
        private readonly IRepositorio _repositorio;
        private readonly IMapper _mapper;

        public OrdenController(ILogger<OrdenController> logger, IRepositorio repositorio, IMapper mapper)
        {
            _logger = logger;
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpGet("LeerOrdenes")]
        public ActionResult<List<OrdenDto>> LeerOrdenes()
        {
            try
            {
                List<Orden> ordenes = _repositorio.ObtenerOrdenes();
                List<Activo> activos = _repositorio.ObtenerActivos();
                List<OrdenDto> ordenesDto = _mapper.Map<List<OrdenDto>>(ordenes);

                foreach (var ordenDto in ordenesDto)
                {
                    ordenDto.NombreActivo = activos.FirstOrDefault(p => p.ID == ordenes.FirstOrDefault(o => o.IDOrden == ordenDto.IDOrden).IDActivo).Nombre;
                }

                return Ok(ordenesDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("CrearOrden")]
        public ActionResult<OrdenDto> CrearOrden([FromBody] OrdenCrearDto orden)
        {
            try
            {
                var activo = _repositorio.BuscarActivo(orden.NombreActivo);

                if (activo == null)
                {
                    return NotFound("No se encontró el activo");
                }

                if (activo.IDTipoActivo != (int)TiposDeActivo.Accion)
                {
                    activo.PrecioUnitario = orden.Precio;
                }

                Cuenta cuenta = _repositorio.BuscarCuenta(orden.IDCuenta);

                if (cuenta == null)
                {
                    return NotFound("No se encontró la cuenta");
                }

                if (cuenta.VigenciaHasta != null)
                {
                    return NotFound("La cuenta no está activa");
                }

                Orden ordenInsert = _mapper.Map<Orden>(orden);
                ordenInsert.IDActivo = activo.ID;
                ordenInsert.Estado = (int)EstadosDeOrden.EnProceso;

                switch (activo.IDTipoActivo)
                {
                    case (int)TiposDeActivo.Accion:
                        ordenInsert.MontoTotal = Accion.CalcularMontoTotal(orden.Cantidad, activo.PrecioUnitario);
                        break;
                    case (int)TiposDeActivo.Bono:
                        ordenInsert.MontoTotal = Bono.CalcularMontoTotal(orden.Cantidad, activo.PrecioUnitario);
                        break;
                    case (int)TiposDeActivo.FCI:
                        ordenInsert.MontoTotal = FCI.CalcularMontoTotal(orden.Cantidad, activo.PrecioUnitario);
                        break;
                }

                _repositorio.CrearOrden(ordenInsert);
                _repositorio.SaveChanges();

                OrdenDto ordenDto = _mapper.Map<OrdenDto>(ordenInsert);
                ordenDto.NombreActivo = orden.NombreActivo;
                return Ok(ordenDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("ActualizarOrden")]
        public ActionResult<OrdenDto> ActualizarOrden([FromBody] OrdenActualizarDto ordenActualizar)
        {
            try
            {
                Orden orden = _repositorio.VerOrdenPorID(ordenActualizar.IDOrden);
                if (orden == null)
                {
                    return NotFound("No se encontró la orden");
                }

                Estado estado = _repositorio.BuscarEstado(ordenActualizar.Estado);
                if (estado == null)
                {
                    return NotFound("No se encontró el estado");
                }

                _mapper.Map(ordenActualizar, orden);
                _repositorio.ActualizarOrden(orden);
                _repositorio.SaveChanges();

                OrdenDto ordenDto = _mapper.Map<OrdenDto>(orden);
                ordenDto.NombreActivo = _repositorio.ObtenerActivos().FirstOrDefault(p => p.ID == _repositorio.ObtenerOrdenes().FirstOrDefault(o => o.IDOrden == ordenDto.IDOrden).IDActivo).Nombre;
                return Ok(_mapper.Map<OrdenDto>(ordenDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("EliminarOrden")]
        public ActionResult<OrdenDto> EliminarOrden(int id)
        {
            try
            {
                var orden = _repositorio.VerOrdenPorID(id);
                if (orden == null)
                {
                    return NotFound("No se encontró la orden");
                }

                _repositorio.EliminarOrden(orden);
                _repositorio.SaveChanges();
                return Ok("Se eliminó la orden exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
