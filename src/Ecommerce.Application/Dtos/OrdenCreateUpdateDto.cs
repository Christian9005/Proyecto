
using System.ComponentModel.DataAnnotations;
using Ecommerce.Domain;

namespace Ecommerce.Application.Dtos;

public class OrdenCreateDto
{
    [Required]
    public Guid ClienteId {get; set;}
    public virtual ICollection<OrdenItemCreateUpdateDto> Items {get; set;}

    [Required]
    public DateTime Fecha {get; set;}
    public string? Observaciones {get; set;}

}

public class OrdenUpdateDto
{
    public string? Observaciones {get; set;}

    [Required]
    public OrdenEstado Estado {get; set;}
}