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

    public async Task<RiskResponseDTO> InsertAsync(RiskInsertRequestDTO riskInsertRequestDto)
    {
        var riskEntity = await _riskRepository.AddAsync(riskInsertRequestDto.ToEntity());
        await _riskRepository.SaveChangesAsync();
        return riskEntity.ToDto();
    }

    public async Task<RiskResponseDTO> UpdateAsync(int riskId, RiskUpdateRequestDTO riskUpdateRequestDto)
    {
        var riskEntity = await _riskRepository.GetByIdAsync(riskId) ?? throw new Exception();
        riskEntity.Mapper(riskUpdateRequestDto);
        _riskRepository.Update(riskEntity);
        await _riskRepository.SaveChangesAsync();
        return riskEntity.ToDto();
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