using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain;

public class Cliente
{
    [Required]
    public int Id {get; set;}

    [Required]
    [StringLength(Constantes.MAX_LEN)]
    public string? NombreCompleto{get; set;}

    [Required]
    [StringLength(Constantes.MAX_LEN_EMAIL)]
    public string? Correo {get; set;}
    
}
