

using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entidades;
using Ecommerce.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application;

public class CartAppService : ICartAppService
{
    private readonly ICartRepository cartRepository;
    private readonly IProductoAppService productoAppService;
    private readonly ILogger<CartAppService> logger;

    public CartAppService(ICartRepository cartRepository, IProductoAppService productoAppService,
                            ILogger<CartAppService> logger)
    {
        this.cartRepository = cartRepository;
        this.productoAppService = productoAppService;
        this.logger = logger;
    }

    public async Task<bool> DeleteAsync(Guid cartId)
    {
        var cart = await cartRepository.GetByIdAsync(cartId);
        if(cart == null)
        {
            throw new ArgumentException($"El carrito con el id: {cartId}, no existe!!");
        }

        cartRepository.Delete(cart);
        await cartRepository.UnitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<CartDto> CreateAsync(CartCreateDto cartDto)
    {
        logger.LogInformation("Crear Cart");

        var cart = new Cart(Guid.NewGuid());
        cart.ClienteId  = cartDto.ClienteId;

        var observaciones = string.Empty;
        foreach (var item in cartDto.Items)
        {
            var productoDto = await productoAppService.GetByIdAsync(item.ProductId);
            if (productoDto != null)
            {
                var cartItem = new CartItems(Guid.NewGuid());
                cartItem.Cantidad = item.Cantidad;
                cartItem.Precio = productoDto.Precio;
                cartItem.ProductId = productoDto.Id;
                
                cart.AgregarItem(cartItem);
            }
            else
            {
                observaciones+=$"El producto {item.ProductId}, no existe!!";
            }
        }

        cart.SubTotal = cart.Items.Sum(it => it.Cantidad * it.Precio);
        cart.Observaciones = observaciones;

        cart = await cartRepository.AddAsync(cart);
        await cartRepository.UnitOfWork.SaveChangesAsync();
        
        return await GetByIdAsync(cart.Id);
    }

    public ListaPaginada<CartDto> GetAll(int limit = 10, int offset = 0)
    {
        var consulta = cartRepository.GetAllIncluding(ca => ca.Cliente, ca =>ca.Items);
        var total = consulta.Count();

        var consultaListaCartDto = consulta.Skip(offset).Take(limit)
                                                .Select(
                                                    ca => new CartDto()
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
                                                                                    Product = item.Product.Nombre,
                                                                                    CartId = item.CartId,
                                                                                    Cantidad = item.Cantidad,
                                                                                    Precio = item.Precio
                                                                                }).ToList()
                                                    }
                                                );
        
        var resultado = new ListaPaginada<CartDto>();
        resultado.Total = total;
        resultado.Lista = consultaListaCartDto.ToList();
        
        return resultado;
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
                                                                                    Product = item.Product.Nombre,
                                                                                    CartId = item.CartId,
                                                                                    Cantidad = item.Cantidad,
                                                                                    Precio = item.Precio
                                                                                }).ToList()
                                                        
                                                    });
        

        return Task.FromResult(consultaCartDto.SingleOrDefault());
    }

    public async Task UpdateAsync(Guid cartId, CartUpdateDto cartDto)
    {
        var cart = await cartRepository.GetByIdAsync(cartId);
        if (cart == null)
        {
            throw new ArgumentException($"El Carrito con el id: {cartId}, no existe!!");
        }

        cart.Observaciones = cartDto.Observaciones;

        await cartRepository.UpdateAsync(cart);
        await cartRepository.UnitOfWork.SaveChangesAsync();

        return;
    }
}
