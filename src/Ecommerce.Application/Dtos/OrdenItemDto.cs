
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Dtos;

public class OrdenItemDto
{
    [Required]
    public Guid Id {get; set;}

    [Required]
    public int ProductId {get; set;}

    public virtual string? Product {get; set;}

    [Required]
    public Guid OrdenId {get; set;}

    [Required]
    public long Cantidad {get; set;}

    public decimal Precio {get; set;}

    public string? Observaciones {get; set;}
}
