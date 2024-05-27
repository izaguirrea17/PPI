using Microsoft.EntityFrameworkCore;
using PPIChallenge.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PPIChallenge.Data
{
    public class SqlRepositorio : IRepositorio
    {
        private readonly DataContext _context;

        public SqlRepositorio(DataContext context) 
        {
            _context = context;
        }

        public void ActualizarOrden(Orden orden)
        {
            _context.Ordenes.Update(orden);
        }

        public void EliminarOrden(Orden orden)
        {
            _context.Ordenes.Remove(orden);
        }

        public void CrearOrden(Orden orden)
        {
            if (orden == null)
            {
                throw new ArgumentNullException();
            }

            _context.Ordenes.Add(orden);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>0);
        }

        public List<Orden> ObtenerOrdenes()
        {
            return _context.Ordenes.ToList();
        }

        public List<Activo> ObtenerActivos()
        {
            return _context.Activos.ToList();
        }

        public Orden VerOrdenPorID(int id) 
        {
            return _context.Ordenes.FirstOrDefault(p => p.IDOrden == id );
        }

        public Activo BuscarActivo(string nombre)
        {
            return _context.Activos.FirstOrDefault(p => p.Nombre == nombre);
        }

        public Cuenta BuscarCuenta(int id)
        {
            return _context.Cuentas.FirstOrDefault(p => p.IDCuenta == id);
        }

        public Estado BuscarEstado(int id)
        {
            return _context.Estados.FirstOrDefault(p => p.ID == id);
        }
    }
}
