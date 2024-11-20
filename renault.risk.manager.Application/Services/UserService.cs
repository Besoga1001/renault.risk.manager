using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using renault.risk.manager.Application.Extensions;
using renault.risk.manager.Application.Helpers;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.RequestDTOs.UserDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Services;

public class UserService : IUserService
{
    private readonly IConfiguration configuration;
    private readonly IUserRepository userRepository;
    private readonly IMetierService metierService;

    // ReSharper disable once ConvertToPrimaryConstructor
    public UserService(
        IConfiguration configuration,
        IUserRepository userRepository,
        IMetierService metierService)
    {
        this.configuration = configuration;
        this.userRepository = userRepository;
        this.metierService = metierService;
    }

    public async Task<AccessTokenResponseDTO> Login(UserLoginRequestDTO userLoginRequestDto)
    {
        var userEntity = await userRepository.GetByEmailAsync(userLoginRequestDto.UsrEmail);
        if (userEntity == null) throw new UnauthorizedAccessException();

        var isPasswordValid = PasswordHasherHelper.VerifyPassword(
            userLoginRequestDto.UsrPassword, userEntity.usr_password_hash, userEntity.usr_password_salt);
        if (!isPasswordValid) throw new UnauthorizedAccessException();

        return new AccessTokenResponseDTO(
            GenerateJwtToken(userLoginRequestDto.UsrEmail),
            DateTime.Now
        );
    }

    private string GenerateJwtToken(string email)
    {
        var jwtSettings = configuration.GetSection("Jwt");
        var key = Encoding.ASCII.GetBytes(jwtSettings["Key"] ?? string.Empty);

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, email)
            }),
            Expires = DateTime.UtcNow.AddHours(8),
            Issuer = jwtSettings["Issuer"],
            Audience = jwtSettings["Audience"],
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task InsertRangeAsync(List<UserInsertRequestDTO> userInsertRequestDtos)
    {
        var responseList = new List<tb_user>();
        foreach (var userInsertRequestDto in userInsertRequestDtos)
        {
            PasswordHasherHelper.HashPassword(userInsertRequestDto.UsrPassword,
                out var passwordHash, out var passwordSalt);

            var metierEntities = await metierService.GetMetiersByIds(userInsertRequestDto.UsrMetiers);

            responseList.Add(userInsertRequestDto
                .ToEntity(passwordHash, passwordSalt, metierEntities));
        }
        await userRepository.AddRangeAsync(responseList);
        await userRepository.SaveChangesAsync();
    }

    public async Task InsertAsync(UserInsertRequestDTO userInsertRequestDto)
    {
        PasswordHasherHelper.HashPassword(userInsertRequestDto.UsrPassword,
            out var passwordHash, out var passwordSalt);

        var metierEntities = await metierService
            .GetMetiersByIds(userInsertRequestDto.UsrMetiers);

        var userEntity = userInsertRequestDto
            .ToEntity(passwordHash, passwordSalt, metierEntities);
        await userRepository.AddAsync(userEntity);
        await userRepository.SaveChangesAsync();
    }
}