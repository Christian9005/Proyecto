

using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application;

public class CartAppService : ICartAppService
{
    private readonly ICartRepository cartRepository;
    private readonly ICartAppService cartAppService;
    private readonly ILogger<CartAppService> logger;

    public CartAppService(ICartRepository cartRepository, ICartAppService cartAppService,
                            ILogger<CartAppService> logger)
    {
        this.cartRepository = cartRepository;
        this.cartAppService = cartAppService;
        this.logger = logger;
    }

    public Task<bool> CancelAsync(Guid cartId)
    {
        throw new NotImplementedException();
    }

    public Task<CartDto> CreateAsync(CartCreateDto cartDto)
    {
        throw new NotImplementedException();
    }

    public ListaPaginada<CartDto> GetAll(int limit = 10, int offset = 0)
    {
        throw new NotImplementedException();
    }

    public Task<CartDto> GetByIdAsync(Guid cartId)
    {
        var consulta = cartRepository.GetAllIncluding(ca => ca.Cliente, ca => ca.Items);
        consulta = consulta.Where(ca => ca.Id == cartId);

        var consultaCartDto = consulta.Select(ca => new CartDto()
                                                    {
                                                        Id = ca.Id,
                                                        ClienteId = ca.ClienteId,
                                                        Cliente = ca.Cliente.NombreCompleto,
                                                        SubTotal = ca.SubTotal,
                                                        Observaciones = ca.Observaciones,
                                                        Items = ca.Items.Select(item => new CartItemsDto()
                                                                                {
                                                                                    Id = item.Id,
                                                                                    ProductId = item.ProductId,
                                                                                    Producto = item.Producto.Nombre,
                                                                                    CartId = item.CartId,
                                                                                    Cantidad = item.Cantidad,
                                                                                    Precio = item.Precio
                                                                                }).ToList()
                                                        
                                                    });
        

        return Task.FromResult(consultaCartDto.SingleOrDefault());
    }

    public Task UpdateAsync(Guid cartId, CartUpdateDto cartDto)
    {
        throw new NotImplementedException();
    }
}
