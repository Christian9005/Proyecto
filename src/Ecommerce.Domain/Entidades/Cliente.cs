using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain;

public class Cliente
{
    public Cliente(Guid id)
    {
        this.Id = id;
    }

    [Required]
    public Guid Id {get; set;}

    [Required]
    [StringLength(Constantes.MAX_LEN)]
    public string? NombreCompleto{get; set;}

    [Required]
    [StringLength(Constantes.MAX_LEN_CI)]
    public string? Cedula {get; set;}
    
    [Required]
    [EmailAddress]
    [StringLength(Constantes.MAX_LEN_EMAIL)]
    public string? Correo {get; set;}
    
    [Required]
    public int Edad {get; set;}

    [Required]
    [StringLength(Constantes.MAX_LEN_AD)]
    public string? Direccion {get; set;}

    [Required]
    [StringLength(Constantes.MAX_LEN_CE)]
    public string? NumeroCelular {get; set;}
}
