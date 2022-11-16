using AutoMapper;
using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application;


public class TipoProductoAppService : ITipoProductoAppService
{
    private readonly ITipoProductoRepository repository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    //private readonly IValidator<TipoProductoCreateUpdateDto> validator;
    private readonly ILogger<TipoProductoAppService> logger;
    public TipoProductoAppService(ITipoProductoRepository repository, IUnitOfWork unitOfWork,
            /*IValidator<TipoProductoCreateUpdateDto> validator, */ILogger<TipoProductoAppService> logger,
            IMapper mapper)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        //this.validator = validator;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<TipoProductoDto> CreateAsync(TipoProductoCreateUpdateDto tipoProductoDto)
    {
        logger.LogInformation("Crear Tipo Producto");

        // var validationResult = await validator.ValidateAsync(tipoProductoDto);
        // if (!validationResult.IsValid)
        // {
        //     var listaErrores = validationResult.Errors.Select(
        //             x => x.ErrorMessage
        //     );

        //     var erroresString = string.Join(" - ", listaErrores);
        //     throw new ArgumentException(erroresString);
        // }

        var existNameTipoProducto = await repository.ExistNameAsync(tipoProductoDto.Nombre);
        if (existNameTipoProducto)
        {
            var msg = $"Ya existe un tipo producto con el siguiente nombre: {tipoProductoDto.Nombre}";
            logger.LogError(msg);

            throw new ArgumentException(msg);
        }

        var tipoProducto = mapper.Map<TipoProducto>(tipoProductoDto);

        tipoProducto = await repository.AddAsync(tipoProducto);
        await repository.UnitOfWork.SaveChangesAsync();

        var tipoProductoCreado = mapper.Map<TipoProductoDto>(tipoProducto);
        return tipoProductoCreado;

    }

    public async Task<bool> DeleteAsync(int tipoProductoId)
    {
        var tipoProducto = await repository.GetByIdAsync(tipoProductoId);
        if (tipoProducto == null)
        {
            throw new ArgumentException($"El tipo producto con el id: {tipoProductoId}, no existe!!");
        }

        repository.Delete(tipoProducto);

        return true;
    }

    public ICollection<TipoProductoDto> GetAll()
    {
        var tipoProductoList = repository.GetAll();

        var tipoProductoListDto = from tp in tipoProductoList
                                    select new TipoProductoDto(){
                                        Id = tp.Id,
                                        Nombre = tp.Nombre
                                    };
        
        return tipoProductoListDto.ToList();
    }

    public async Task UpdateAsync(int tipoProductoId, TipoProductoCreateUpdateDto tipoProductoDto)
    {
        var tipoProducto = await repository.GetByIdAsync(tipoProductoId);
        if (tipoProducto == null)
        {
            throw new ArgumentException($"El tipo de producto con el id: {tipoProductoId}, no existe!!");
        }

        var existNameTipoProducto = await repository.ExistNameAsync(tipoProductoDto.Nombre, tipoProductoId);
        if (existNameTipoProducto)
        {
            throw new ArgumentException($"Ya existe un tipo producto con el nombre: {tipoProductoDto.Nombre}");
        }

        tipoProducto.Nombre = tipoProductoDto.Nombre;
        
        await repository.UpdateAsync(tipoProducto);
        await repository.UnitOfWork.SaveChangesAsync();

        return;
    }
}
