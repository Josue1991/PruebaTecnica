using System.ComponentModel.DataAnnotations;

namespace Blazzor.Client.Modelos
{
    public class CrearMovimientoStock
    {
        [Required(ErrorMessage = "El tipo es requerido")]
        [Range(1, 2, ErrorMessage = "Seleccione un tipo válido")]
        public int Tipo { get; set; } = 1;

        [Required(ErrorMessage = "La cantidad es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "La razón es requerida")]
        [StringLength(200, ErrorMessage = "La razón no puede exceder los 200 caracteres")]
        public string Razon { get; set; } = string.Empty;
    }
}
