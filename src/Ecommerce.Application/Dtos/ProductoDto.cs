using System.ComponentModel.DataAnnotations;
using Ecommerce.Domain;

namespace Ecommerce.Application.Dtos;

public class ProductoDto
{
    [Required]
    public int Id {get; set;}

    [Required]
    [StringLength(Constantes.MAX_LEN)]
    public string? Nombre {get; set;}

    public decimal Precio {get; set;}

    public string? Observaciones {get; set;}
    
    public DateTime Caducidad {get; set;}

    [Required]
    public string MarcaId {get; set;}

    public string? Marca {get; set;}

    [Required]
    public int TipoProductoId {get; set;}

    public string? TipoProducto {get; set;}
}
