using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain;

public class Marca
{
    
    [Required]
    [StringLength(Constantes.MAX_LEN_ID)]
    public string Id {get; set;}
    
    [Required]
    [StringLength(Constantes.MAX_LEN)]
    public string? Nombre {get; set;}
}

