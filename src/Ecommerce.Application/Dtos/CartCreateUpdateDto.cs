using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Dtos;

public class CartCreateDto
{
    [Required]
    public Guid ClienteId {get; set;}
    public virtual ICollection<CartItemsCreateUpdateDto> Items {get; set;}
    
    public string? Observaciones {get; set;}
}

public class CartUpdateDto
{
    public string? Observaciones {get; set;}
}


