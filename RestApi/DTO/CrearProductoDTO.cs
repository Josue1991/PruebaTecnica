using System.ComponentModel.DataAnnotations;

namespace RestApi.DTO
{
    public class CrearProductoDTO
    {
        [Required]
        [MaxLength(100)]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Codigo { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Categoria { get; set; } = string.Empty;

        public int CantidadStock { get; set; }

        public decimal PrecioUnitario { get; set; }
    }
}
