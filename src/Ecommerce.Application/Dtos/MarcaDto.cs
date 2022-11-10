
using System.ComponentModel.DataAnnotations;
using Ecommerce.Domain;

namespace Ecommerce.Application.Dtos;

public class MarcaDto
{
    [Required]
    [StringLength(Constantes.MAX_LEN_ID)]
    public string Id {get; set;}
    
    [Required]
    [StringLength(Constantes.MAX_LEN)]
    public string? Nombre {get; set;}
}
