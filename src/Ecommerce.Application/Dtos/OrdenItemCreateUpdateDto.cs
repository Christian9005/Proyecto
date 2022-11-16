using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Dtos;

public class OrdenItemCreateUpdateDto
{
    [Required]
    public int ProductId {get; set;}
    
    [Required]
    public long Cantidad {get; set;}
    public string? Observaciones {get; set;}
}
