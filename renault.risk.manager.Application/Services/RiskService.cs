using renault.risk.manager.Application.Extensions;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Application.Interfaces.Services;
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

    public async Task<RiskResponseDTO> InsertAsync(RiskRequestDTO riskRequestDto)
    {
        var riskEntidade = riskRequestDto.toEntity();
        var riskEntity = await _riskRepository.AddAsync(riskEntidade);
        var boolean = await _riskRepository.SaveChangesAsync();
        return riskEntity.toDto();
    }

    public async Task<RiskResponseDTO> UpdateAsync(RiskRequestDTO riskRequestDto)
    {
        throw new NotImplementedException();
    }

    public async Task<List<RiskResponseDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<RiskResponseDTO> GetByIdAsync(int riskId)
    {
        throw new NotImplementedException();
    }

}