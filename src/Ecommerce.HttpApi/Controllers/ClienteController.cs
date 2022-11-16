using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.HttpApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteAppService clienteAppService;

    public ClienteController(IClienteAppService clienteAppService)
    {
        this.clienteAppService = clienteAppService;
    }

    [HttpGet]
    public ICollection<ClienteDto> GetAll(int limit = 10, int offset = 0)
    {
        return clienteAppService.GetAll(limit, offset);
    }

    [HttpPost]
    public async Task<ClienteDto> CreateAsync(ClienteCreateUpdateDto clienteDto)
    {
        return await clienteAppService.CreateAsync(clienteDto);
    }

    [HttpPut]
    public async Task UpdateAsync(Guid clienteId, ClienteCreateUpdateDto clienteDto)
    {
        await clienteAppService.UpdateAsync(clienteId, clienteDto);
    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(Guid clienteId)
    {
        return await clienteAppService.DeleteAsync(clienteId);
    }
}
