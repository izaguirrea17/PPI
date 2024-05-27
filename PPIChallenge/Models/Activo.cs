using System.ComponentModel.DataAnnotations;

namespace PPIChallenge.Models
{
    public class Activo
    {
        [Required]
        [Key]
        public int ID { get; set; }

        [Required]
        public string Ticker { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public int IDTipoActivo { get; set; }

        [Required]
        public decimal PrecioUnitario { get; set; }

    }
}
