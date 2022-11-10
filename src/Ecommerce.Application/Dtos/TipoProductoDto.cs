
using System.ComponentModel.DataAnnotations;
using Ecommerce.Domain;

namespace Ecommerce.Application;

public class TipoProductoDto
{
    [Required]
    public int Id {get; set;}
    
    [Required]
    [StringLength(Constantes.MAX_LEN)]
    public string? Nombre {get; set;}
}
