using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entidades;

public class CartItems
{
    public CartItems(Guid id)
    {
        this.Id = id;
    }

    [Required]
    public Guid Id {get; set;}

    [Required]
    public int ProductId {get; set;}
    public virtual Producto Product{get; set;}

    [Required]
    public Guid CartId {get; set;}
    public virtual Cart Cart {get; set;}

    [Required]
    public long Cantidad {get; set;}
    public decimal Precio {get; set;}
}
