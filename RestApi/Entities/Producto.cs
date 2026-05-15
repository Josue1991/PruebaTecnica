using RestApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace RestApi.Entities
{
    public class Producto
    {
        public int Id { get; set; }

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

        public DateTime Creado { get; set; } = DateTime.UtcNow;

        public ICollection<MovimientoStock> StockMovements { get; set; }
            = new List<MovimientoStock>();
    }
}
