using renault.risk.manager.Application.Extensions;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.RequestDTOs.MetierDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Services;

public class MetierService : IMetierService
{
    private readonly IMetierRepository metierRepository;

    // ReSharper disable once ConvertToPrimaryConstructor
    public MetierService(IMetierRepository metierRepository)
    {
        this.metierRepository = metierRepository;
    }

    public async Task<MetierResponseDTO> Insert(MetierRequestDTO metierRequestDto)
    {
        var metierEntity = await metierRepository.AddAsync(metierRequestDto.ToEntity());
        await metierRepository.SaveChangesAsync();
        return metierEntity.ToDto();
    }

    public async Task<string> Update(int metierId, MetierUpdateDTO metierUpdateDto)
    {
        var metierEntity = await metierRepository.GetByIdAsync(metierId);
        metierEntity.Mapper(metierUpdateDto);

        metierRepository.Update(metierEntity);
        await metierRepository.SaveChangesAsync();

        return "Record Successfully Updated";
    }

    public async Task<MetierResponseDTO> GetByIdAsync(int metierId)
    {
        var metierEntity = await metierRepository.GetByIdAsync(metierId);
        return metierEntity.ToDto();
    }

    public async Task<List<MetierResponseDTO>> GetAllAsync(string? metierDescription)
    {
        var metierEntities = await metierRepository.GetAllAsync(null, metierDescription);
        return metierEntities.Select(j => j.ToDto()).ToList();
    }

    public async Task<string> Delete(int metierId)
    {
        metierRepository.Remove(metierId);
        await metierRepository.SaveChangesAsync();
        return $"Successfully to Delete Register with ID: {metierId}";
    }

    public async Task<List<tb_metier>> GetMetiersByIds(List<int> metierIds)
    {
        var metierEntities = new List<tb_metier>();
        foreach (var metierId in metierIds)
        {
            var metierEntity = await metierRepository.GetByIdAsync(metierId);
            metierEntities.Add(metierEntity);
        }
        return metierEntities;
    }
}