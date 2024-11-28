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
    private readonly IUserRepository userRepository;
    private readonly IRiskService riskService;

    public SolutionService(
        ISolutionRepository solutionRepository,
        IUserRepository userRepository,
        IRiskService riskService)
    {
        this.solutionRepository = solutionRepository;
        this.userRepository = userRepository;
        this.riskService = riskService;
    }

    public async Task<SolutionResponseDTO> InsertAsync(SolutionInsertRequestDTO solutionInsertRequestDto)
    {
        var solutionEntity = await solutionRepository.AddAsync(solutionInsertRequestDto.ToEntity());
        await riskService.UpdateRiskStatus(solutionInsertRequestDto.SlnRiskId);
        await solutionRepository.SaveChangesAsync();
        return solutionEntity.ToDto("");
    }

    public async Task<SolutionResponseDTO> UpdateAsync(int solutionId, SolutionUpdateRequestDTO solutionUpdateRequestDTO)
    {
        var solutionEntity = await solutionRepository.GetByIdAsync(solutionId);
        solutionEntity.Mapper(solutionUpdateRequestDTO);

        solutionRepository.Update(solutionEntity);
        await solutionRepository.SaveChangesAsync();

        return solutionEntity.ToDto("");
    }

    public async Task<List<SolutionResponseDTO>> GetAllAsync()
    {
        var solutionEntities = await solutionRepository.GetAllAsync();
        return solutionEntities.Select(s => s.ToDto("")).ToList();
    }

    public async Task<SolutionResponseDTO> GetByIdAsync(int riskId)
    {
        var solutionEntity = await solutionRepository.GetByIdAsync(riskId);
        var userEntity = await userRepository.GetByIdAsync(solutionEntity.sln_user_pilot_id);
        return solutionEntity.ToDto(userEntity.usr_name);
    }

    public SolutionFieldOptionsResponseDTO GetFieldOptions() => SolutionExtensions.GetFieldOptions();

}