using System.ComponentModel.DataAnnotations;


namespace Ecommerce.Application.Dtos;

public class CartItemsDto
{
    [Required]
    public Guid Id {get; set;}

    [Required]
    public int ProductId {get; set;}
    public virtual string? Producto{get; set;}

    [Required]
    public Guid CartId {get; set;}

    [Required]
    public long Cantidad {get; set;}
    public decimal Precio {get; set;}
}
