using renault.risk.manager.Application.Extensions;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.RequestDTOs;

namespace renault.risk.manager.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly IMetierRepository metierRepository;

    // ReSharper disable once ConvertToPrimaryConstructor
    public UserService(IUserRepository userRepository, IMetierRepository metierRepository)
    {
        this.userRepository = userRepository;
        this.metierRepository = metierRepository;
    }

    public async Task InsertRangeAsync(List<UserInsertRequestDTO> userInsertRequestDtos)
    {
        var metierEntities = new List<tb_metier>();
        foreach (var metierDescription in userInsertRequestDtos
                     .SelectMany(userInsertRequestDto => userInsertRequestDto.UsrMetiers))
        {
            var response = await metierRepository.GetAllAsync(null, metierDescription);
            var metierEntity = response.FirstOrDefault();
            if (metierEntity != null) metierEntities.Add(metierEntity);
        }

        var list = userInsertRequestDtos.Select(x => x.ToEntity(metierEntities)).ToList();
        await userRepository.AddRangeAsync(list);
        await userRepository.SaveChangesAsync();
    }

    public async void ValidateUser(string email)
    {
        var listUserEntity = await userRepository.GetByEmailAsync(email);
        var userEntity = listUserEntity.FirstOrDefault();

        if (userEntity != null)
        {
            UpdateUserAsync(userEntity);
        }
        else
        {
            InsertUserAsync(email);
        }
        
        await userRepository.SaveChangesAsync();
    }

    private async void InsertUserAsync(string email)
    {
        var userEntity = new tb_user
        {
            usr_email = email,
            usr_name = "To Do", //TODO
            usr_created_at = DateTime.Now,
            usr_updated_at = null
        };

        await userRepository.AddAsync(userEntity);
    }
    
    private void UpdateUserAsync(tb_user userEntity)
    {
        userEntity.usr_updated_at = DateTime.Now; //Updated At = Last Login (In This Case)
        userRepository.Update(userEntity);
    }
}