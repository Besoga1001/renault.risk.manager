using renault.risk.manager.Application.Extensions;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Services;

public class SolutionService : ISolutionService
{
    private readonly ISolutionRepository _solutionRepository;

    public SolutionService(ISolutionRepository solutionRepository)
    {
        _solutionRepository = solutionRepository;
    }

    public async Task<SolutionResponseDTO> InsertAsync(SolutionRequestDTO solutionRequestDto)
    {
        var solutionEntity = await _solutionRepository.AddAsync(solutionRequestDto.toEntity());
        await _solutionRepository.SaveChangesAsync();
        return solutionEntity.toDto();
    }

    public async Task<SolutionResponseDTO> UpdateAsync(SolutionRequestDTO riskRequestDto)
    {
        throw new NotImplementedException();
    }

    public async Task<List<SolutionResponseDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<SolutionResponseDTO> GetByIdAsync(int riskId)
    {
        throw new NotImplementedException();
    }
}