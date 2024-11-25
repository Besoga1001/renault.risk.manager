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
using renault.risk.manager.Domain.ResponseDTOs.Risk;

namespace renault.risk.manager.Application.Services;

public class RiskService : IRiskService
{
    private readonly IJalonRepository jalonRepository;
    private readonly IMetierRepository metierRepository;
    private readonly IProjectRepository projectRepository;
    private readonly IRiskRepository riskRepository;

    // ReSharper disable once ConvertToPrimaryConstructor
    public RiskService(
        IJalonRepository jalonRepository,
        IMetierRepository metierRepository,
        IProjectRepository projectRepository,
        IRiskRepository riskRepository)
    {
        this.jalonRepository = jalonRepository;
        this.metierRepository = metierRepository;
        this.projectRepository = projectRepository;
        this.riskRepository = riskRepository;
    }

    public async Task<int> InsertAsync(RiskInsertRequestDTO riskInsertRequestDto)
    {
        var riskEntity = await riskRepository.AddAsync(riskInsertRequestDto.ToEntity());
        await riskRepository.SaveChangesAsync();
        return riskEntity.rsk_id;
    }

    public async Task InsertRangeAsync(List<RiskInsertRequestDTO> riskInsertRequestDtos)
    {
        var list = riskInsertRequestDtos.Select(x => x.ToEntity()).ToList();
        await riskRepository.AddRangeAsync(list);
        await riskRepository.SaveChangesAsync();
    }

    public async Task<RiskResponseDTO> UpdateAsync(int riskId, RiskUpdateRequestDTO riskUpdateRequestDto)
    {
        var riskEntity = await GetEntityByIdAsync(riskId);

        riskEntity.Mapper(riskUpdateRequestDto);
        riskRepository.Update(riskEntity);
        await riskRepository.SaveChangesAsync();
        return riskEntity.ToDto();
    }

    public async Task<List<RiskResponseDTO>> GetAllAsync(RiskFiltersDTO riskFiltersDto)
    {
        var riskEntities = await riskRepository.GetAllAsync(riskFiltersDto);
        return riskEntities.Select(riskEntity => riskEntity.ToDto()).ToList();
    }

    public async Task<RiskResponseDTO> GetByIdAsync(int riskId)
    {
        var riskEntity = await GetEntityByIdAsync(riskId);
        return riskEntity.ToDto();
    }

    public RiskFieldOptionsResponseDTO GetFieldOptions()
    {
        var projectEntities = projectRepository.GetAll();
        var jalonEntities = jalonRepository.GetAll();
        var metierEntities = metierRepository.GetAll();
        return RiskExtensions.GetFieldOptions(projectEntities, jalonEntities, metierEntities);
    }

    public async Task UpdateRiskStatus(int riskId)
    {
        var riskEntity = await riskRepository.GetByIdAsync(riskId);
        riskEntity.rsk_status = RiskStatusEnum.Solved;
        riskRepository.Update(riskEntity);
        await riskRepository.SaveChangesAsync();
    }

    private async Task<tb_risk> GetEntityByIdAsync(int riskId)
    {
        return await riskRepository.GetByIdAsync(riskId)
            ?? throw new NotFoundException($"No record found with the specified ID: {riskId}.");
    }

}