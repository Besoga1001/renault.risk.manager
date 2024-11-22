using renault.risk.manager.Domain.RequestDTOs.UserDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Interfaces.Services;

public interface IUserService
{
    Task InsertRangeAsync(List<UserInsertRequestDTO> userInsertRequestDtos);
    Task<AccessTokenResponseDTO> Login(UserLoginRequestDTO userLoginRequestDto);
    Task InsertAsync(UserInsertRequestDTO userInsertRequestDto);
}