

using Ecommerce.Application;
using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.HttpApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private readonly IProductoAppService productoAppService;

    public ProductoController(IProductoAppService productoAppService)
    {
        this.productoAppService = productoAppService;
    }

    [HttpGet]
    public ListaPaginada<ProductoDto> GetAll(int limit = 10, int offset = 0)
    {
        return productoAppService.GetAll(limit, offset);
    }

    [HttpGet("list")]
    public Task<ListaPaginada<ProductoDto>> GetListAsync([FromQuery]ProductoListInput input)
    {
        return productoAppService.GetListAsync(input);
    }

    [HttpGet("{id}")]
    public async Task<ProductoDto> GetByIdAsync(int id)
    {
        return await productoAppService.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<ProductoDto> CreateAsync(ProductoCreateUpdateDto producto)
    {
        return await productoAppService.CreateAsync(producto);
    }

    [HttpPut]
    public async Task UpdateAsync(int id, ProductoCreateUpdateDto producto)
    {
        await productoAppService.UpdateAsync(id, producto);
    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(int id)
    {
        return await productoAppService.DeleteAsync(id);
    }

}
