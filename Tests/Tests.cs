using AutoMapper;
using Microsoft.Extensions.Logging;
using NUnit.Framework.Internal;
using PPIChallenge.Controllers;
using PPIChallenge.Data;
using PPIChallenge.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using PPIChallenge.Profiles;
using Azure;
using PPIChallenge.Models;
using PPIChallenge.DTOs;

namespace Tests
{
    public class Tests
    {
        private OrdenController _controller;
        private readonly ILogger<OrdenController> _logger;
        

        [SetUp]
        public void Setup()
        {
            var profile = new OrdenProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            IMapper mapper = new Mapper(configuration);
            _controller = new OrdenController(_logger, new FakeRepositorio(), mapper);
            
        }

        [Test]
        public void VerificaSiLeerOrdenesNoDevuelveNull()
        {
            ActionResult<List<OrdenDto>> result = _controller.LeerOrdenes();

            Assert.That(result.Result, Is.Not.Null);
        }

        [Test]
        public void CrearOrdenExitosamente()
        {
            OrdenCrearDto orden = new OrdenCrearDto() {
                IDCuenta=1, 
                NombreActivo= "Apple", 
                Cantidad=1,
                Precio=2,
                Operacion="V"
            };

            var response = _controller.CrearOrden(orden);
            OkObjectResult result = (OkObjectResult)response.Result;
            //Verifica que el nombre del activo devuelto es igual al enviado
            Assert.That(((OrdenDto)(result.Value)).NombreActivo, Is.EqualTo("Apple"));
        }

        [Test]
        public void CrearOrdenErrorDeCuenta()
        {
            OrdenCrearDto orden = new OrdenCrearDto()
            {
                IDCuenta = 100,
                NombreActivo = "Apple",
                Cantidad = 1,
                Precio = 2,
                Operacion = "V"
            };

            var response = _controller.CrearOrden(orden);
            NotFoundObjectResult result = (NotFoundObjectResult)response.Result;
            Assert.That(result.Value, Is.EqualTo("No se encontró la cuenta"));
        }
        [Test]
        public void CrearOrdenErrorDeActivo()
        {
            OrdenCrearDto orden = new OrdenCrearDto()
            {
                IDCuenta = 1,
                NombreActivo = "Test",
                Cantidad = 1,
                Precio = 2,
                Operacion = "V"
            };

            var response = _controller.CrearOrden(orden);
            NotFoundObjectResult result = (NotFoundObjectResult)response.Result;
            Assert.That(result.Value, Is.EqualTo("No se encontró el activo"));
        }

        [Test]
        public void ActualizarOrdenErrorDeOrden()
        {
            OrdenActualizarDto orden = new OrdenActualizarDto()
            {
                IDOrden = 1000,
                Estado = 1
            };

            var response = _controller.ActualizarOrden(orden);
            NotFoundObjectResult result = (NotFoundObjectResult)response.Result;
            Assert.That(result.Value, Is.EqualTo("No se encontró la orden"));
        }

        [Test]
        public void ActualizarOrden()
        {
            OrdenActualizarDto orden = new OrdenActualizarDto()
            {
                IDOrden = 1,
                Estado = 1
            };

            var response = _controller.ActualizarOrden(orden);
            OkObjectResult result = (OkObjectResult)response.Result;
            //Verifica que el IDOrden devuelto es igual al enviado
            Assert.That(((OrdenDto)result.Value).IDOrden, Is.EqualTo(orden.IDOrden));
        }

        [Test]
        public void EliminarOrden()
        {

            var response = _controller.EliminarOrden(1);
            OkObjectResult result = (OkObjectResult)response.Result;
            Assert.That(result.Value, Is.EqualTo("Se eliminó la orden exitosamente"));
        }

    }
}