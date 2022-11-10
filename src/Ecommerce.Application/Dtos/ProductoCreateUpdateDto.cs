using System.ComponentModel.DataAnnotations;
using Ecommerce.Domain;

namespace Ecommerce.Application.Dtos;

public class ProductoCreateUpdateDto
{

    [Required]
    [StringLength(Constantes.MAX_LEN)]
    public string? Nombre {get; set;}
    public decimal Precio {get; set;}
    public string? Observaciones {get; set;}
    public DateTime Caducidad {get; set;}

    [Required]
    public int MarcaId {get; set;}

    [Required]
    public int TipoProductoId {get; set;}

}
