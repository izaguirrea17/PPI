using System.ComponentModel.DataAnnotations;

namespace PPIChallenge.Dtos
{
    public class OrdenDto
    {
        public int IDOrden { get; set; }

        public int IDCuenta { get; set; }

        [Required]
        [MaxLength(32)]
        public string NombreActivo { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public string Operacion { get; set; }

        public int Estado { get; set; }

        public decimal MontoTotal { get; set; }
    }
}