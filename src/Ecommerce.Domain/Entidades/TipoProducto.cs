using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain;

public class TipoProducto
{
    [Required]
    public int Id {get; set;}
    
    [Required]
    [StringLength(Constantes.MAX_LEN)]
    public string? Nombre {get; set;}
}
