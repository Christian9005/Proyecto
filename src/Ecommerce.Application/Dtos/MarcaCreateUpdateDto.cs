

using System.ComponentModel.DataAnnotations;
using Ecommerce.Domain;

namespace Ecommerce.Application.Dtos;

public class MarcaCreateUpdateDto
{
    [Required]
    [StringLength(Constantes.MAX_LEN)]
    public string? Nombre {get; set;}
}
