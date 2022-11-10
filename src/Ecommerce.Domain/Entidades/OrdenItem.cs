using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain;

public class OrdenItem
{
    [Required]
    public Guid Id {get; set;}

    [Required]
    public int ProducId {get; set;}

    public virtual Producto? Product {get; set;}

    [Required]
    public int OrdenId {get; set;}

    public virtual Orden? Orden {get; set;}

    [Required]
    public long Cantidad {get; set;}

    public decimal Precio {get; set;}

    public string? Observaciones {get; set;}
}
