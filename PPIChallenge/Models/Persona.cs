using System.ComponentModel.DataAnnotations;

namespace PPIChallenge.Models
{
    public class Persona
    {

        [Required]
        [Key]
        public int IDPersona { get; set; }

        [Required]
        public string CUIL { get; set; }

        [Required]
        public string RazonSocial { get; set; }

        [Required]
        public string Mail { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public int IDTipoPersona { get; set; }
    }
}
