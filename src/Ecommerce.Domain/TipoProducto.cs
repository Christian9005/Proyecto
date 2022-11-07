using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain;

public class TipoProducto
{
    [Required]
    public int Id {get; set;}
    
    [Required]
    [StringLength(Constantes.MAX_LEN)]
    public string? Nombre {get; set;}
}
