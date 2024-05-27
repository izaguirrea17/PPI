using System.ComponentModel.DataAnnotations;

namespace PPIChallenge.Models
{
    public class Cuenta
    {

        [Required]
        [Key]
        public int IDCuenta { get; set; }

        [Required]
        public int IDPersona { get; set; }

        [Required]
        public DateTime VigenciaDesde { get; set; }

        public DateTime? VigenciaHasta { get; set; }
    }
}
