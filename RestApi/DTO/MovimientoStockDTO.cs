using RestApi.Enums;

namespace RestApi.DTO
{
    public class MovimientoStockDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public MovimientoStock Tipo { get; set; }

        public int Cantidad { get; set; }

        public string Razon { get; set; } = string.Empty;

        public DateTime Creado { get; set; }
    }
}
