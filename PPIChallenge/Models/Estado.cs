using System.ComponentModel.DataAnnotations;

namespace PPIChallenge.Models
{
    public class Estado
    {
        [Required]
        [Key]
        public int ID { get; set; }

        [Required]
        public string DescripcionEstado { get; set; }

    }
}