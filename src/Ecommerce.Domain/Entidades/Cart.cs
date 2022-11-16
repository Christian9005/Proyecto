using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entidades;

public class Cart
{
    public Cart(Guid id)
    {
        this.Id = id;
    }

    [Required]
    public Guid Id {get; set;}

    [Required]
    public Guid ClienteId {get; set;}
    public virtual Cliente Cliente{get; set;}
    public virtual ICollection<CartItems> Items {get; set;} = new List<CartItems>();
    
    [Required]
    public decimal SubTotal {get; set;}

    public string? Observaciones {get; set;}

    public void AgregarItem(CartItems item)
    {
        item.Cart = this;
        Items.Add(item);
    }
}
