namespace PPIChallenge.Enums
{
    public class Enums
    {
        public enum TiposDeActivo
        {
            Accion = 1,
            Bono = 2,
            FCI = 3
        }

        public enum EstadosDeOrden
        {
            EnProceso = 0,
            Ejecutada = 1,
            Cancelada = 3
        }

        public struct Comisiones
        {
            public const double ComisionAccion = 0.6;
            public const double Impuestos = 0.21;
            public const double ComisionBono = 0.2;
        }

    }
}
