using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.Entities;

namespace renault.risk.manager.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    // ReSharper disable once ConvertToPrimaryConstructor
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async void ValidateUser(string email)
    {
        var listUserEntity = await _userRepository.GetByEmailAsync(email);
        var userEntity = listUserEntity.FirstOrDefault();

        if (userEntity != null)
        {
            UpdateUserAsync(userEntity);
        }
        else
        {
            InsertUserAsync(email);
        }
        
        await _userRepository.SaveChangesAsync();
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

        await _userRepository.AddAsync(userEntity);
    }
    
    private void UpdateUserAsync(tb_user userEntity)
    {
        userEntity.usr_updated_at = DateTime.Now; //Updated At = Last Login (In This Case)
        _userRepository.Update(userEntity);
    }
}