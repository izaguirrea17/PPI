using System.ComponentModel.DataAnnotations;

namespace PPIChallenge.Models
{
    public class TipoPersona
    {
        [Required]
        [Key]
        public int IDTipoPersona { get; set; }

        [Required]
        public string TipoDePersona { get; set; }
    }
}
