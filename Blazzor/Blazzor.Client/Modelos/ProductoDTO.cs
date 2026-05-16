namespace Blazzor.Client.Modelos
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public int CantidadStock { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
