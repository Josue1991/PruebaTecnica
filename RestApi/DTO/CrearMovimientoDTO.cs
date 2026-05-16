using RestApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace RestApi.DTO
{
    public class CrearMovimientoDTO
    {
        [Required]
        public MovimientoStock Tipo { get; set; }

        [Range(1, int.MaxValue)]
        public int Cantidad { get; set; }

        [Required]
        [MaxLength(200)]
        public string Razon { get; set; } = string.Empty;
    }
}
