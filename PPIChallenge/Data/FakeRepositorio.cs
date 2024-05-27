using Azure;
using Microsoft.EntityFrameworkCore;
using PPIChallenge.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PPIChallenge.Data
{
    public class FakeRepositorio : IRepositorio
    {
        bool savedChanges = false;
        public List<Orden> Ordenes = new List<Orden>() { 
            new Orden(){ IDOrden=1, IDCuenta= 1, IDActivo= 1, Cantidad=1, Precio=5, Operacion="C", Estado=1, MontoTotal= 5},
            new Orden(){ IDOrden=2, IDCuenta= 2, IDActivo= 6, Cantidad=1, Precio=2, Operacion="V", Estado=0, MontoTotal= 5},
            new Orden(){ IDOrden=3, IDCuenta= 1, IDActivo= 1, Cantidad=1, Precio=5, Operacion="C", Estado=3, MontoTotal= 5},
            new Orden(){ IDOrden=4, IDCuenta= 2, IDActivo= 8, Cantidad=1, Precio=2, Operacion="V", Estado=1, MontoTotal= 5},
        };
        public List<Activo> Activos = new List<Activo>() { 
            new Activo(){  ID=1, Ticker="AAPL", Nombre="Apple", IDTipoActivo=1, PrecioUnitario= 5 },
            new Activo(){  ID=6, Ticker="AL30", Nombre="BONOS ARGENTINA USD 2030 L.A", IDTipoActivo=2, PrecioUnitario= 15 },
            new Activo(){  ID=8, Ticker="Delta.Pesos", Nombre="Delta Pesos Clase A", IDTipoActivo=3, PrecioUnitario= 25 },
        };
        public List<Cuenta> Cuentas = new List<Cuenta>() {
            new Cuenta() {IDCuenta =1,
                IDPersona=1,
                VigenciaDesde=new DateTime(DateTime.Now.Year, 1, 1),
                VigenciaHasta=null},
            new Cuenta() {IDCuenta =2,
                IDPersona= 2,
                VigenciaDesde= new DateTime(DateTime.Now.Year, 1, 1),
                VigenciaHasta=  new DateTime(DateTime.Now.Year, 2, 1),}

        };
        public List<Estado> Estados = new List<Estado>() {
            new Estado() {ID =0,
                DescripcionEstado= "En proceso"},
            new Estado() {ID =1,
                DescripcionEstado= "Ejecutada"},
            new Estado() {ID =3,
                DescripcionEstado= "Cancelada"},
        };


        public void ActualizarOrden(Orden orden)
        {
            Ordenes.Single(x => x.IDOrden == orden.IDOrden).Estado = orden.Estado;
            savedChanges = true;
        }

        public void EliminarOrden(Orden orden)
        {
            savedChanges = true;
        }

        public void CrearOrden(Orden orden)
        {
            if (orden == null)
            {
                throw new ArgumentNullException();
            }
            orden.IDOrden = Ordenes.Count + 1;
            Ordenes.Add(orden);
            savedChanges = true;
        }

        public List<Orden> ObtenerOrdenes()
        {
            return Ordenes;
        }

        public List<Activo> ObtenerActivos()
        {
            return Activos;
        }

        public Orden VerOrdenPorID(int id)
        {
            return Ordenes.FirstOrDefault(p => p.IDOrden == id);
        }

        public Activo BuscarActivo(string nombre)
        {
            return Activos.FirstOrDefault(p => p.Nombre == nombre);
        }

        public Cuenta BuscarCuenta(int id)
        {
            return Cuentas.FirstOrDefault(p => p.IDCuenta == id);
        }

        public Estado BuscarEstado(int id)
        {
            return Estados.FirstOrDefault(p => p.ID == id);
        }

        public bool SaveChanges()
        {
            savedChanges = true;
            return savedChanges;
        }
    }
}
