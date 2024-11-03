using renault.risk.manager.Application.Extensions;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Services;

public class JalonService : IJalonService
{
    private readonly IJalonRepository _jalonRepository;

    // ReSharper disable once ConvertToPrimaryConstructor
    public JalonService(IJalonRepository jalonRepository)
    {
        _jalonRepository = jalonRepository;
    }

    public async Task<JalonResponseDTO> Insert(JalonRequestDTO jalonRequestDto)
    {
        var jalonEntity = await _jalonRepository.AddAsync(jalonRequestDto.ToEntity());
        await _jalonRepository.SaveChangesAsync();
        return jalonEntity.ToDto();
    }

    public async Task<JalonResponseDTO> GetByIdAsync(int jalonId)
    {
        var jalonEntity = await _jalonRepository.GetByIdAsync(jalonId);
        return jalonEntity.ToDto();
    }

    public async Task<List<JalonResponseDTO>> GetAllAsync(string? jalonDescription)
    {
        var jalonEntities = await _jalonRepository.GetAllAsync(jalonDescription);
        return jalonEntities.Select(j => j.ToDto()).ToList();
    }

    public async Task<string> Delete(int jalonId)
    {
        _jalonRepository.Remove(jalonId);
        await _jalonRepository.SaveChangesAsync();
        return $"Successfully to Delete Register with ID: {jalonId}";
    }
}