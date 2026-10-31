using System.ComponentModel.DataAnnotations;

namespace Proyecto.DTOs;

public class CreateProductoDTO {

    [Required]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
    public string Nombre { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser positivo")]
    public decimal Precio { get; set; }
    public string Descripcion { get; set; }

    [Required]
    public bool Activo { get; set; }
}