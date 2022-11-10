using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain;

public class Orden
{
    [Required]
    public Guid Id {get; set;}

    [Required]
    public int ClienteId {get; set;}

    public virtual Cliente? Cliente {get; set;}

    public virtual ICollection<OrdenItem>? Items {get; set;}

    [Required]
    public DateTime Fecha {get; set;}

    public DateTime FechaAnulacion {get; set;}

    [Required]
    public decimal Total {get; set;}

    public string? Observaciones {get; set;}

    [Required]
    public OrdenEstado Estado {get; set;}

    public void Agregaritem(OrdenItem item)
    {
        item.Orden = this;
        Items.Add(item);
    }

}
