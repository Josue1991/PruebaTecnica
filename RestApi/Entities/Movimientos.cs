using RestApi.Enums;

namespace RestApi.Entities
{
    public class Movimientos
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Producto Product { get; set; } = default!;

        public MovimientoStock Type { get; set; }

        public int Cantidad { get; set; }

        public string Razon { get; set; } = string.Empty;

        public DateTime FechaMovimiento { get; set; } = DateTime.UtcNow;
    }
}
