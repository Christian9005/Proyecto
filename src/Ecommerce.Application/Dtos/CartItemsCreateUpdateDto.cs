using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Dtos;

public class CartItemsCreateUpdateDto
{
    [Required]
    public int ProductId {get; set;}
    public virtual string? Producto{get; set;}

    [Required]
    public long Cantidad {get; set;}
    public decimal Precio {get; set;}
}
