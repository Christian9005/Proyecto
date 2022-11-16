
using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain;
using Ecommerce.Domain.Repository;

namespace Ecommerce.Application;

public class ProductoAppService : IProductoAppService
{
    private readonly IProductoRepository productoRepository;
    private readonly IMarcaRepository marcaRepository;
    private readonly ITipoProductoRepository tipoProductoRepository;

    public ProductoAppService(IProductoRepository productoRepository, 
                        IMarcaRepository marcaRepository,
                        ITipoProductoRepository tipoProductoRepository)
    {
        this.productoRepository = productoRepository;
        this.marcaRepository = marcaRepository;
        this.tipoProductoRepository = tipoProductoRepository;
    }

    public async Task<ProductoDto> CreateAsync(ProductoCreateUpdateDto productoDto)
    {
        var producto = new Producto();
        producto.Caducidad = productoDto.Caducidad;
        producto.MarcaId = productoDto.MarcaId;
        producto.Nombre = productoDto.Nombre;
        producto.Observaciones = productoDto.Observaciones;
        producto.Precio = productoDto.Precio;
        producto.TipoProductoId = productoDto.TipoProductoId;

        producto = await productoRepository.AddAsync(producto);
        await productoRepository.UnitOfWork.SaveChangesAsync();

        return await GetByIdAsync(producto.Id);
    }

    public async Task<bool> DeleteAsync(int productoId)
    {
        var producto = await productoRepository.GetByIdAsync(productoId);
        if(producto == null)
        {
            throw new ArgumentException($"El prodcuto con el id: {productoId}, no existe!!");
        }

        productoRepository.Delete(producto);
        await productoRepository.UnitOfWork.SaveChangesAsync();

        return true;    
    }

    public ListaPaginada<ProductoDto> GetAll(int limit = 10, int offset = 0)
    {
        var consulta = productoRepository.GetAllIncluding(p => p.Marca, p => p.TipoProducto);

        var total = consulta.Count();

        var consultaListaProductoDto = consulta.Skip(offset).Take(limit)
                                                .Select(
                                                    p => new ProductoDto()
                                                    {
                                                        Id = p.Id,
                                                        Caducidad = p.Caducidad,
                                                        Marca = p.Marca.Nombre,
                                                        MarcaId = p.MarcaId,
                                                        Nombre = p.Nombre,
                                                        Observaciones = p.Observaciones,
                                                        Precio = p.Precio,
                                                        TipoProducto = p.TipoProducto.Nombre,
                                                        TipoProductoId = p.TipoProductoId
                                                    }
                                                );
        
        var resultado = new ListaPaginada<ProductoDto>();
        resultado.Total = total;
        resultado.Lista = consultaListaProductoDto.ToList();
        
        return resultado;
    }

    public Task<ProductoDto> GetByIdAsync(int id)
    {
        var consulta = productoRepository.GetAllIncluding(p => p.TipoProducto, p => p.Marca);
        consulta = consulta.Where(p => p.Id == id);

        var consultaProductoDto = consulta.Select(
                                    p => new ProductoDto()
                                    {
                                        Id = p.Id,
                                        Caducidad = p.Caducidad,
                                        Marca = p.Marca.Nombre,
                                        MarcaId = p.MarcaId,
                                        Nombre = p.Nombre,
                                        Observaciones = p.Observaciones,
                                        Precio = p.Precio,
                                        TipoProducto = p.TipoProducto.Nombre,
                                        TipoProductoId = p.TipoProductoId
                                    }

        );

        return Task.FromResult(consultaProductoDto.SingleOrDefault());
    }

    public async Task<ListaPaginada<ProductoDto>> GetListAsync(ProductoListInput input)
    {
        var consulta = productoRepository.GetAllIncluding(p => p.Marca, p => p.TipoProducto);

        if (input.TipoProductoId.HasValue)
        {
            consulta = consulta.Where(p => p.TipoProductoId == input.TipoProductoId);
        }

        if (input.MarcaId != null)
        {
            consulta = consulta.Where(p => p.MarcaId == input.MarcaId);
        }

        if (!string.IsNullOrEmpty(input.ValorBuscar))
        {
            consulta = consulta.Where(p => p.Nombre.Contains(input.ValorBuscar));
        }

        var total = consulta.Count();

        consulta = consulta.Skip(input.Offset).Take(input.Limit);

        var consultaListaProductoDto =  consulta.Select(
                                                    p => new ProductoDto()
                                                    {
                                                        Id = p.Id,
                                                        Caducidad = p.Caducidad,
                                                        Marca = p.Marca.Nombre,
                                                        MarcaId = p.MarcaId,
                                                        Nombre = p.Nombre,
                                                        Observaciones = p.Observaciones,
                                                        Precio = p.Precio,
                                                        TipoProducto = p.TipoProducto.Nombre,
                                                        TipoProductoId = p.TipoProductoId
                                                    }
                                            );
        
        var resultado = new ListaPaginada<ProductoDto>();
        resultado.Lista = consultaListaProductoDto.ToList();
        resultado.Total = total;

        return resultado;
    }

    public async Task UpdateAsync(int productoId, ProductoCreateUpdateDto productoDto)
    {
        var producto = await productoRepository.GetByIdAsync(productoId);
        if (producto == null)
        {
            throw new ArgumentException($"El producto con el id: {productoId}, no existe!!");
        }

        producto.Caducidad = productoDto.Caducidad;
        producto.MarcaId = productoDto.MarcaId;
        producto.Nombre = productoDto.Nombre;
        producto.Observaciones = productoDto.Observaciones;
        producto.Precio = productoDto.Precio;
        producto.TipoProductoId = productoDto.TipoProductoId;

        await productoRepository.UpdateAsync(producto);
        await productoRepository.UnitOfWork.SaveChangesAsync();

        return;
    }
}
