using System.ComponentModel.DataAnnotations;
using Ecommerce.Domain;

namespace Ecommerce.Application.Dtos;

public class OrdenDto
{
    [Required]
    public Guid Id {get; set;}

    [Required]
    public Guid ClienteId {get; set;}

    public virtual string? Cliente {get; set;}

    public virtual ICollection<OrdenItemDto>? Items {get; set;}

    [Required]
    public DateTime Fecha {get; set;}

    public DateTime FechaAnulacion {get; set;}

    [Required]
    public decimal Total {get; set;}

    public string? Observaciones {get; set;}

    [Required]
    public OrdenEstado Estado {get; set;}

}

