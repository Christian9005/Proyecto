using Ecommerce.Application;
using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.HttpApi.Controllers;

[ApiController]
[Route("[controller]")]

public class OrdenController : ControllerBase
{
    private readonly IOrdenAppService ordenAppService;

    public OrdenController(IOrdenAppService ordenAppService)
    {
        this.ordenAppService = ordenAppService;
    }

    [HttpGet]
    public ListaPaginada<OrdenDto> GetAll(int limit = 10, int offset =0)
    {
        return ordenAppService.GetAll(limit, offset);
    }

    [HttpGet("{ordenId}")]
    public async Task<OrdenDto> GetByIdAsync(Guid ordenId)
    {
        return await ordenAppService.GetByIdAsync(ordenId);
    }

    [HttpPost]
    public async Task<OrdenDto> CreateAsync(OrdenCreateDto orden)
    {
        return await ordenAppService.CreateAsync(orden);
    }

    [HttpPut]
    public async Task UpdateAsync(Guid ordenId, OrdenUpdateDto orden)
    {
        await ordenAppService.UpdateAsync(ordenId, orden);
    }

    [HttpDelete]
    public async Task<bool> CancelAsync(Guid ordenId)
    {
        return await ordenAppService.CancelAsync(ordenId);
    }
}
