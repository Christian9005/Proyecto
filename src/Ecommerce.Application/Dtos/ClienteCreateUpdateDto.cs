using System.ComponentModel.DataAnnotations;
using Ecommerce.Domain;

namespace Ecommerce.Application.Dtos;

public class ClienteCreateUpdateDto
{
    [Required]
    [StringLength(Constantes.MAX_LEN_CI)]
    public string? Cedula {get; set;}

    [Required]
    [StringLength(Constantes.MAX_LEN)]
    public string? NombreCompleto{get; set;}

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

