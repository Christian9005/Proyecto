
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Dtos;

public class CartDto
{
    [Required]
    public Guid Id {get; set;}

    [Required]
    public Guid ClienteId {get; set;}
    public virtual string? Cliente{get; set;}
    public virtual ICollection<CartItemsDto> Items {get; set;}
    public string? Observaciones {get; set;}
    
    [Required]
    public decimal SubTotal {get; set;}
}
