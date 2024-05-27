
namespace PPIChallenge.Models
{
    public class FCI
    {
        public static decimal CalcularMontoTotal(int cantidad, decimal precio)
        {
            return ((decimal)cantidad* precio);
        }
    }
}