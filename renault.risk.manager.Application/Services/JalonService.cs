using renault.risk.manager.Application.Extensions;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.RequestDTOs.JalonDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Services;

public class JalonService : IJalonService
{
    private readonly IJalonRepository jalonRepository;

    // ReSharper disable once ConvertToPrimaryConstructor
    public JalonService(IJalonRepository jalonRepository)
    {
        this.jalonRepository = jalonRepository;
    }

    public async Task<JalonResponseDTO> Insert(JalonRequestDTO jalonRequestDto)
    {
        var jalonEntity = await jalonRepository.AddAsync(jalonRequestDto.ToEntity());
        await jalonRepository.SaveChangesAsync();
        return jalonEntity.ToDto();
    }

    public async Task<string> Update(int jalonId, JalonUpdateDTO jalonUpdateDto)
    {
        var jalonEntity = await jalonRepository.GetByIdAsync(jalonId);
        jalonEntity.Mapper(jalonUpdateDto);

        jalonRepository.Update(jalonEntity);
        await jalonRepository.SaveChangesAsync();

        return "Record Successfully Updated";
    }

    public async Task<JalonResponseDTO> GetByIdAsync(int jalonId)
    {
        var jalonEntity = await jalonRepository.GetByIdAsync(jalonId);
        return jalonEntity.ToDto();
    }

    public async Task<List<JalonResponseDTO>> GetAllAsync(string? jalonDescription)
    {
        var jalonEntities = await jalonRepository.GetAllAsync(jalonDescription);
        return jalonEntities.Select(j => j.ToDto()).ToList();
    }

    public async Task<string> Delete(int jalonId)
    {
        jalonRepository.Remove(jalonId);
        await jalonRepository.SaveChangesAsync();
        return $"Successfully to Delete Register with ID: {jalonId}";
    }
}