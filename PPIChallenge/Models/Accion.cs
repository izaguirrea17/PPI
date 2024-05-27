using static PPIChallenge.Enums.Enums;

namespace PPIChallenge.Models
{
    public class Accion
    {

        public static decimal CalcularMontoTotal(int cantidad, decimal precio)
        {
            decimal totalBruto = (decimal)cantidad * precio;
            decimal comisiones = (totalBruto * (decimal)Comisiones.ComisionAccion);
            decimal impuestos = comisiones * (decimal)Comisiones.Impuestos;
            return (totalBruto-comisiones-impuestos);
        }
    }
}