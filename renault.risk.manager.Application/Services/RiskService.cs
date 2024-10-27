using renault.risk.manager.Application.Extensions;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.Exceptions;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Services;

public class RiskService : IRiskService
{
    private readonly IRiskRepository _riskRepository;

    public RiskService(IRiskRepository riskRepository)
    {
        _riskRepository = riskRepository;
    }

    public async Task<RiskResponseDTO> InsertAsync(RiskInsertRequestDTO riskInsertRequestDto)
    {
        var riskEntity = await _riskRepository.AddAsync(riskInsertRequestDto.ToEntity());
        await _riskRepository.SaveChangesAsync();
        return riskEntity.ToDto();
    }

    public async Task<RiskResponseDTO> UpdateAsync(int riskId, RiskUpdateRequestDTO riskUpdateRequestDto)
    {
        var riskEntity = await GetEntityByIdAsync(riskId);
        riskEntity.Mapper(riskUpdateRequestDto);
        _riskRepository.Update(riskEntity);
        await _riskRepository.SaveChangesAsync();
        return riskEntity.ToDto();
    }

    public async Task<List<RiskResponseDTO>> GetAllAsync()
    {
        var riskEntities = await _riskRepository.GetAllAsync();
        return riskEntities.Select(riskEntity => riskEntity.ToDto()).ToList();
    }

    public async Task<RiskResponseDTO> GetByIdAsync(int riskId)
    {
        var riskEntity = await GetEntityByIdAsync(riskId);
        return riskEntity.ToDto();
    }

    private async Task<tb_risk> GetEntityByIdAsync(int riskId)
    {
        return await _riskRepository.GetByIdAsync(riskId)
            ?? throw new NotFoundException($"No record found with the specified ID: {riskId}.");
    }

}