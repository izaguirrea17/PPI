using PPIChallenge.Models;

namespace PPIChallenge.Data
{
    public interface IRepositorio
    {
        bool SaveChanges();

        List<Orden> ObtenerOrdenes();
        Orden VerOrdenPorID(int id);
        void CrearOrden(Orden orden);
        void ActualizarOrden(Orden orden);
        void EliminarOrden(Orden orden);
        Activo BuscarActivo(string nombre);
        Cuenta BuscarCuenta(int id);
        List<Activo> ObtenerActivos();
        Estado BuscarEstado(int id);
    }
}
