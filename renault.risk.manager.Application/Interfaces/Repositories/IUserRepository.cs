using renault.risk.manager.Domain.Entities;

namespace renault.risk.manager.Application.Interfaces.Repositories;

public interface IUserRepository : IRepositoryGenerics<tb_user>
{
    Task<List<tb_user>> GetByEmailAsync(string email);
}