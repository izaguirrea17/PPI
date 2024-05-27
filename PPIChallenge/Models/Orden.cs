using System.ComponentModel.DataAnnotations;

namespace PPIChallenge.Models
{
    public class Orden
    {

        [Key]
        public int IDOrden { get; set; }

        [Required]
        public int IDCuenta { get; set; }

        [Required]
        public int IDActivo { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "El valor debe ser mayor que cero")]
        public int Cantidad { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "El valor debe ser mayor que cero")]
        public decimal Precio { get; set; }

        [Required]
        [AllowedValues("C", "V")]
        public string Operacion { get; set; }

        public int Estado { get; set; }

        public decimal MontoTotal { get; set; }
    }
}
