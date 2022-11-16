using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application;

public class MarcaAppService : IMarcaAppService
{
    
    private readonly IMarcaRepository repository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IValidator<MarcaCreateUpdateDto> validator;
    private readonly ILogger<MarcaAppService> logger;
    public MarcaAppService(IMarcaRepository repository, IUnitOfWork unitOfWork,
            IValidator<MarcaCreateUpdateDto> validator, ILogger<MarcaAppService> logger)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        this.validator = validator;
        this.logger = logger;
    }

    public async Task<MarcaDto> CreateAsync(MarcaCreateUpdateDto marcaDto)
    {
        logger.LogInformation("Crear Marca");

        var validationResult = await validator.ValidateAsync(marcaDto);
        if(!validationResult.IsValid)
        {
            var listaErrores = validationResult.Errors.Select(
                    x => x.ErrorMessage
            );

            var erroresString = string.Join(" - ", listaErrores);
            throw new ArgumentException(erroresString);
        }

        var existNameMarca = await repository.ExistNameAsync(marcaDto.Nombre);
        if (existNameMarca)
        {
            var msg = $"Ya existe una marca con el siguiente nombre: {marcaDto.Nombre}";
            logger.LogError(msg);

            throw new ArgumentException(msg);
        }
        
        
        var marcaId = new IdString();
        var marca = new Marca();
        marca.Id = marcaId.StringId();
        marca.Nombre = marcaDto.Nombre;

        marca = await repository.AddAsync(marca);
        await unitOfWork.SaveChangesAsync();

        var marcaCreada = new MarcaDto();
        marcaCreada.Id = marca.Id;
        marcaCreada.Nombre = marca.Nombre;

        return marcaCreada;
    }

    public async Task<bool> DeleteAsync(string marcaId)
    {
        var marca = await repository.GetByIdAsync(marcaId);
        if (marca == null)
        {
            throw new ArgumentException($"La marca con el id: {marcaId}, no existe");
        }

        repository.Delete(marca);
        await repository.UnitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<MarcaDto> GetAll()
    {
        var marcaList = repository.GetAll();

        var marcaListDto = from m in marcaList
                            select new MarcaDto(){
                                Id = m.Id,
                                Nombre = m.Nombre
                            };
        
        return marcaListDto.ToList();
    }

    public async Task UpdateAsync(string marcaId, MarcaCreateUpdateDto marcaDto)
    {
        var marca = await repository.GetByIdAsync(marcaId);
        if (marca == null)
        {
            throw new ArgumentException($"La marca con el id: {marcaId}, no existe");
        }

        var existNameMarca = await repository.ExistNameAsync(marcaDto.Nombre, marcaId);
        if (existNameMarca)
        {
            throw new ArgumentException($"Ya existe una marca con el nombre {marcaDto.Nombre}");
        }

        marca.Nombre = marcaDto.Nombre;

        await repository.UpdateAsync(marca);
        await repository.UnitOfWork.SaveChangesAsync();
        
        return;
    }
}

public class IdString
{
    public string LetrasNumeros = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        
    public string StringId()
    {
        var stringChars = new char[4];
        var random = new Random();

        for (int i = 0; i<stringChars.Length; i++)
        {
            stringChars[i] = LetrasNumeros[random.Next(LetrasNumeros.Length)];
        }
        return new String(stringChars);
    }
}