using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Repository;
using Ecommerce.Domain;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application;

public class OrdenAppService : IOrdenAppService
{
    private readonly IOrdenRepository ordenRepository;
    private readonly IProductoAppService productoAppService;
    private readonly ILogger<OrdenAppService> logger;

    public OrdenAppService(IOrdenRepository ordenRepository, 
                    IProductoAppService productoAppService,
                    ILogger<OrdenAppService> logger)
    {
        this.ordenRepository = ordenRepository;
        this.productoAppService = productoAppService;
        this.logger = logger;
    }

    public Task<bool> CancelAsync(Guid ordenId)
    {
        throw new NotImplementedException();
    }

    public async Task<OrdenDto> CreateAsync(OrdenCreateDto ordenDto)
    {
        logger.LogInformation("Crear Orden");

        var orden = new Orden(Guid.NewGuid());
        orden.ClienteId  = ordenDto.ClienteId;
        orden.Estado = OrdenEstado.Registrada;
        orden.Fecha = ordenDto.Fecha;

        var observaciones = string.Empty;
        foreach (var item in ordenDto.Items)
        {
            var productoDto = await productoAppService.GetByIdAsync(item.ProductId);
            if (productoDto != null)
            {
                var ordenItem = new OrdenItem(Guid.NewGuid());
                ordenItem.Cantidad = item.Cantidad;
                ordenItem.Precio = productoDto.Precio;
                ordenItem.ProductId = productoDto.Id;
                ordenItem.Observaciones = item.Observaciones;

                orden.AgregarItem(ordenItem);
            }
            else
            {
                observaciones+=$"El producto {item.ProductId}, no existe!!";
            }
        }

        orden.Total = orden.Items.Sum(it => it.Cantidad * it.Precio);
        orden.Observaciones = observaciones;

        orden = await ordenRepository.AddAsync(orden);
        await ordenRepository.UnitOfWork.SaveChangesAsync();
        
        return await GetByIdAsync(orden.Id);
    }

    public ListaPaginada<OrdenDto> GetAll(int limit = 10, int offset = 0)
    {
        var consulta = ordenRepository.GetAllIncluding(or => or.Cliente, or =>or.Items);
        var total = consulta.Count();

        var consultaListaOrdenDto = consulta.Skip(offset).Take(limit)
                                                .Select(
                                                    or => new OrdenDto()
                                                    {
                                                        Id = or.Id,
                                                        ClienteId = or.ClienteId,
                                                        Cliente = or.Cliente.NombreCompleto,
                                                        Fecha = or.Fecha,
                                                        FechaAnulacion = or.FechaAnulacion,
                                                        Total = or.Total,
                                                        Observaciones = or.Observaciones,
                                                        Estado = or.Estado,
                                                        Items = or.Items.Select(item => new OrdenItemDto()
                                                                                {
                                                                                    Id = item.Id,
                                                                                    ProductId = item.ProductId,
                                                                                    Product = item.Product.Nombre,
                                                                                    OrdenId = item.OrdenId,
                                                                                    Cantidad = item.Cantidad,
                                                                                    Precio = item.Precio,
                                                                                    Observaciones = item.Observaciones
                                                                                }).ToList()
                                                    }
                                                );
        
        var resultado = new ListaPaginada<OrdenDto>();
        resultado.Total = total;
        resultado.Lista = consultaListaOrdenDto.ToList();
        
        return resultado;
    }

    public Task<OrdenDto> GetByIdAsync(Guid ordenId)
    {
        var consulta = ordenRepository.GetAllIncluding(or => or.Cliente, or => or.Items);
        consulta = consulta.Where(or => or.Id == ordenId);

        var consultaOrdenDto = consulta.Select(or => new OrdenDto()
                                                    {
                                                        Id = or.Id,
                                                        ClienteId = or.ClienteId,
                                                        Cliente = or.Cliente.NombreCompleto,
                                                        Estado = or.Estado,
                                                        Fecha = or.Fecha,
                                                        FechaAnulacion = or.FechaAnulacion,
                                                        Total = or.Total,
                                                        Observaciones = or.Observaciones,
                                                        Items = or.Items.Select(item => new OrdenItemDto()
                                                                                {
                                                                                    Id = item.Id,
                                                                                    ProductId = item.ProductId,
                                                                                    Product = item.Product.Nombre,
                                                                                    OrdenId = item.OrdenId,
                                                                                    Cantidad = item.Cantidad,
                                                                                    Precio = item.Precio,
                                                                                    Observaciones = item.Observaciones
                                                                                }).ToList()
                                                        
                                                    });
        

        return Task.FromResult(consultaOrdenDto.SingleOrDefault());
    }

    public async Task UpdateAsync(Guid ordenId, OrdenUpdateDto ordenDto)
    {
        var orden = await ordenRepository.GetByIdAsync(ordenId);
        if (orden == null)
        {
            throw new ArgumentException($"La orden con el id: {ordenId}, no existe!!");
        }

        orden.Estado = ordenDto.Estado;
        orden.Observaciones = ordenDto.Observaciones;

        await ordenRepository.UpdateAsync(orden);
        await ordenRepository.UnitOfWork.SaveChangesAsync();

        return;
    }
}
