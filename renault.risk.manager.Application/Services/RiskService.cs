using renault.risk.manager.Application.Extensions;
using renault.risk.manager.Application.Helpers;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.Enums;
using renault.risk.manager.Domain.Exceptions;
using renault.risk.manager.Domain.FiltersDTOs;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.RequestDTOs.RiskDTOs;
using renault.risk.manager.Domain.ResponseDTOs;
using renault.risk.manager.Domain.ResponseDTOs.Risk;

namespace renault.risk.manager.Application.Services;

public class RiskService : IRiskService
{
    private readonly IMetierRepository _metierRepository;
    private readonly IUserRepository _userRepository;
    private readonly IRiskRepository _riskRepository;

    // ReSharper disable once ConvertToPrimaryConstructor
    public RiskService(
        IMetierRepository metierRepository,
        IUserRepository userRepository,
        IRiskRepository riskRepository)
    {
        _metierRepository = metierRepository;
        _userRepository = userRepository;
        _riskRepository = riskRepository;
    }

    public async Task<RiskResponseDTO> InsertAsync(RiskInsertRequestDTO riskInsertRequestDto)
    {
        var riskEntity = await _riskRepository.AddAsync(riskInsertRequestDto.ToEntity());
        await _riskRepository.SaveChangesAsync();
        return riskEntity.ToDto();
    }

    public async Task InsertRangeAsync(List<RiskInsertRequestDTO> riskInsertRequestDtos)
    {
        var list = riskInsertRequestDtos.Select(x => x.ToEntity()).ToList();
        await _riskRepository.AddRangeAsync(list);
        await _riskRepository.SaveChangesAsync();
    }

    public async Task<RiskResponseDTO> UpdateAsync(int riskId, RiskUpdateRequestDTO riskUpdateRequestDto)
    {
        var riskEntity = await GetEntityByIdAsync(riskId);
        riskEntity.Mapper(riskUpdateRequestDto);
        _riskRepository.Update(riskEntity);
        await _riskRepository.SaveChangesAsync();
        return riskEntity.ToDto();
    }

    public async Task<List<RiskResponseDTO>> GetAllAsync(RiskFiltersDTO riskFiltersDto)
    {
        if (riskFiltersDto.MetierId != null)
        {
            var metierEntities = await _metierRepository.GetAllAsync(null, null);
        }
        var riskEntities = await _riskRepository.GetAllAsync(riskFiltersDto);
        return riskEntities.Select(riskEntity => riskEntity.ToDto()).ToList();
    }

    public async Task<RiskResponseDTO> GetByIdAsync(int riskId)
    {
        var riskEntity = await GetEntityByIdAsync(riskId);
        return riskEntity.ToDto();
    }

    public RiskFieldOptionsResponseDTO GetFieldOptions() => RiskExtensions.GetFieldOptions();

    private async Task<tb_risk> GetEntityByIdAsync(int riskId)
    {
        return await _riskRepository.GetByIdAsync(riskId)
            ?? throw new NotFoundException($"No record found with the specified ID: {riskId}.");
    }

}