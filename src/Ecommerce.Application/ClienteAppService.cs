using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain;
using Ecommerce.Domain.Repository;

namespace Ecommerce.Application;

public class ClienteAppService : IClienteAppService
{
    private readonly IClienteRepository clienteRepository;

    public ClienteAppService(IClienteRepository clienteRepository)
    {
        this.clienteRepository = clienteRepository;
    }

    public async Task<ClienteDto> CreateAsync(ClienteCreateUpdateDto clienteDto)
    {
        var cliente = new Cliente(Guid.NewGuid());
        cliente.Cedula = clienteDto.Cedula;
        cliente.NombreCompleto = clienteDto.NombreCompleto;
        cliente.Edad = clienteDto.Edad;
        cliente.Correo = clienteDto.Correo;
        cliente.Direccion = clienteDto.Direccion;
        cliente.NumeroCelular = clienteDto.NumeroCelular;

        cliente = await clienteRepository.AddAsync(cliente);
        await clienteRepository.UnitOfWork.SaveChangesAsync();

        var clienteCreado = new ClienteDto();
        clienteCreado.Id = cliente.Id;
        clienteCreado.Cedula = cliente.Cedula;
        clienteCreado.Correo = cliente.Correo;
        clienteCreado.Direccion = cliente.Direccion;
        clienteCreado.Edad = cliente.Edad;
        clienteCreado.NombreCompleto = cliente.NombreCompleto;
        clienteCreado.NumeroCelular = cliente.NumeroCelular;

        return clienteCreado;
    }

    public async Task<bool> DeleteAsync(Guid clienteId)
    {
        var cliente = await clienteRepository.GetByIdAsync(clienteId);
        if (cliente == null)
        {
            throw new ArgumentException($"El cliente con el id: {clienteId}, no existe!!");
        }

        clienteRepository.Delete(cliente);
        await clienteRepository.UnitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<ClienteDto> GetAll(string buscar, int limit = 10, int offset = 0)
    {
        var clientelist = clienteRepository.GetAll();

        var clientelistDto = from c in clientelist
                                select new ClienteDto()
                                {
                                    Id = c.Id,
                                    NombreCompleto = c.NombreCompleto,
                                    Cedula = c.Cedula,
                                    Correo = c.Correo,
                                    Edad = c.Edad,
                                    Direccion = c.Direccion,
                                    NumeroCelular = c.NumeroCelular
                                };
        
        return clientelistDto.ToList();
    }

    public async Task UpdateAsync(Guid clienteId, ClienteCreateUpdateDto clienteDto)
    {
        var cliente = await clienteRepository.GetByIdAsync(clienteId);
        if (cliente == null)
        {
            throw new ArgumentException($"El cliente con el id: {clienteId}, no existe!!");
        }

        cliente.Cedula = clienteDto.Cedula;
        cliente.Edad = clienteDto.Edad;
        cliente.Correo = clienteDto.Correo;
        cliente.NombreCompleto = clienteDto.NombreCompleto;
        cliente.NumeroCelular = clienteDto.NumeroCelular;
        cliente.Direccion = clienteDto.Direccion;

        await clienteRepository.UpdateAsync(cliente);
        await clienteRepository.UnitOfWork.SaveChangesAsync();

        return;
    }
}
