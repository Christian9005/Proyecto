using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Application;
using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.HttpApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CartController: ControllerBase
{
    private readonly ICartAppService cartAppService;

    public CartController(ICartAppService cartAppService)
    {
        this.cartAppService = cartAppService;
    }

    [HttpGet]
    public ListaPaginada<CartDto> GetAll(int limit = 10, int offset =0)
    {
        return cartAppService.GetAll(limit, offset);
    }

    [HttpGet("{ordenId}")]
    public async Task<CartDto> GetByIdAsync(Guid cartId)
    {
        return await cartAppService.GetByIdAsync(cartId);
    }

    [HttpPost]
    public async Task<CartDto> CreateAsync(CartCreateDto cartDto)
    {
        return await cartAppService.CreateAsync(cartDto);
    }

    [HttpPut]
    public async Task UpdateAsync(Guid cartId, CartUpdateDto cartDto)
    {
        await cartAppService.UpdateAsync(cartId, cartDto);
    }

    [HttpDelete]
    public async Task<bool> CancelAsync(Guid cartId)
    {
        return await cartAppService.CancelAsync(cartId);
    }
}
