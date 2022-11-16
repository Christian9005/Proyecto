using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entidades;

public class Stock
{
    public Stock(Guid id)
    {
        this.Id = id;
    }

    [Required]
    public Guid Id{get; set;}

    [Required]
    public int ProductId{get; set;}

    public virtual Producto Producto{get; set;}
    
    [Required]
    public long StockProducto {get; set;}
}
