using System.ComponentModel.DataAnnotations;

namespace PPIChallenge.Dtos
{
    public class OrdenCrearDto
    {
        [Required]
        public int IDCuenta { get; set; }

        [Required]
        [MaxLength(32)]
        public string NombreActivo { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "El valor debe ser mayor que cero")]
        public int Cantidad { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "El valor debe ser mayor que cero")]
        public decimal Precio { get; set; }

        [Required]
        [AllowedValues("C", "V")]
        public string Operacion { get; set; }
    }
}