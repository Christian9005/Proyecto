
using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.HttpApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MarcaController : ControllerBase
{
    private readonly IMarcaAppService marcaAppService;

    public MarcaController(IMarcaAppService marcaAppService)
    {
        this.marcaAppService = marcaAppService;
    }

    [HttpGet]
    public ICollection<MarcaDto> GetAll()
    {
        return marcaAppService.GetAll();
    }

    [HttpPost]
    public async Task<MarcaDto> CreateAsync(MarcaCreateUpdateDto marca)
    {
        return await marcaAppService.CreateAsync(marca);
    }

    [HttpPut]
    public async Task UpdateAsync(string marcaId, MarcaCreateUpdateDto marca)
    {
        await marcaAppService.UpdateAsync(marcaId, marca);
    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(string marcaId)
    {
        return await marcaAppService.DeleteAsync(marcaId);
    }
}
