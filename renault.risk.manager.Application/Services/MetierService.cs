using renault.risk.manager.Application.Extensions;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Services;

public class MetierService : IMetierService
{
    private readonly IMetierRepository _metierRepository;

    // ReSharper disable once ConvertToPrimaryConstructor
    public MetierService(IMetierRepository metierRepository)
    {
        _metierRepository = metierRepository;
    }

    public async Task<MetierResponseDTO> Insert(MetierRequestDTO metierRequestDto)
    {
        var metierEntity = await _metierRepository.AddAsync(metierRequestDto.ToEntity());
        await _metierRepository.SaveChangesAsync();
        return metierEntity.ToDto();
    }

    public async Task<MetierResponseDTO> GetByIdAsync(int metierId)
    {
        var metierEntity = await _metierRepository.GetByIdAsync(metierId);
        return metierEntity.ToDto();
    }

    public async Task<List<MetierResponseDTO>> GetAllAsync(string? metierDescription)
    {
        var metierEntities = await _metierRepository.GetAllAsync(null, metierDescription);
        return metierEntities.Select(j => j.ToDto()).ToList();
    }

    public async Task<string> Delete(int metierId)
    {
        _metierRepository.Remove(metierId);
        await _metierRepository.SaveChangesAsync();
        return $"Successfully to Delete Register with ID: {metierId}";
    }
}