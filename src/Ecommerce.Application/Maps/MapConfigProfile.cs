using AutoMapper;
using Ecommerce.Application.Dtos;
using Ecommerce.Domain;

namespace Ecommerce.Application.Maps;

public class MapConfigProfile : Profile
{
    public MapConfigProfile()
    {
        CreateMap<TipoProductoCreateUpdateDto, TipoProducto>();
        CreateMap<TipoProducto, TipoProductoDto>();
        
    }
}
