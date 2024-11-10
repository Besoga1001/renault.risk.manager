using renault.risk.manager.Application.Extensions;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.RequestDTOs.SolutionDTOs;
using renault.risk.manager.Domain.ResponseDTOs;
using renault.risk.manager.Domain.ResponseDTOs.Solution;

namespace renault.risk.manager.Application.Services;

public class SolutionService : ISolutionService
{
    private readonly ISolutionRepository solutionRepository;

    public SolutionService(ISolutionRepository solutionRepository)
    {
        this.solutionRepository = solutionRepository;
    }

    public async Task<SolutionResponseDTO> InsertAsync(SolutionInsertRequestDTO solutionInsertRequestDto)
    {
        var solutionEntity = await solutionRepository.AddAsync(solutionInsertRequestDto.ToEntity());
        await solutionRepository.SaveChangesAsync();

        return solutionEntity.ToDto();
    }

    public async Task<SolutionResponseDTO> UpdateAsync(int solutionId, SolutionUpdateRequestDTO solutionUpdateRequestDTO)
    {
        var solutionEntity = await solutionRepository.GetByIdAsync(solutionId);
        solutionEntity.Mapper(solutionUpdateRequestDTO);

        solutionRepository.Update(solutionEntity);
        await solutionRepository.SaveChangesAsync();

        return solutionEntity.ToDto();
    }

    public async Task<List<SolutionResponseDTO>> GetAllAsync()
    {
        var solutionEntities = await solutionRepository.GetAllAsync();
        return solutionEntities.Select(s => s.ToDto()).ToList();
    }

    public async Task<SolutionResponseDTO> GetByIdAsync(int riskId)
    {
        var solutionEntity = await solutionRepository.GetByIdAsync(riskId);
        return solutionEntity.ToDto();
    }

    public SolutionFieldOptionsResponseDTO GetFieldOptions() => SolutionExtensions.GetFieldOptions();

}