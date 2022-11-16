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
public class TipoProductoController: ControllerBase
{
    private readonly ITipoProductoAppService tipoProductoAppService;

    public TipoProductoController(ITipoProductoAppService tipoProductoAppService)
    {
        this.tipoProductoAppService = tipoProductoAppService;
    }

    [HttpGet]
    public ICollection<TipoProductoDto> GetAll()
    {
        return tipoProductoAppService.GetAll();
    }

    [HttpPost]
    public async Task<TipoProductoDto> CreateAsync(TipoProductoCreateUpdateDto tipoProducto)
    {
        return await tipoProductoAppService.CreateAsync(tipoProducto);
    }

    [HttpPut]
    public async Task UpdateAsync(int tipoProductoId, TipoProductoCreateUpdateDto tipoProducto)
    {
        await tipoProductoAppService.UpdateAsync(tipoProductoId, tipoProducto);
    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(int tipoProductoId)
    {
        return await tipoProductoAppService.DeleteAsync(tipoProductoId);
    }

}
