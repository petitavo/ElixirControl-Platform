using ElixirControlPlatform.API.IAM.Application.Internal.OutboundServices;
using ElixirControlPlatform.API.IAM.Domain.Model.Aggregates;
using ElixirControlPlatform.API.IAM.Domain.Model.Commands;
using ElixirControlPlatform.API.IAM.Domain.Repositories;
using ElixirControlPlatform.API.IAM.Domain.Services;
using ElixirControlPlatform.API.Shared.Domain.Repositories;

namespace ElixirControlPlatform.API.IAM.Application.Internal.CommandServices;

/// <summary>
/// User command service 
/// </summary>
/// <param name="userRepository">
/// The <see cref="IUserRepository"/> instance
/// </param>
/// <param name="tokenService">
/// The <see cref="ITokenService"/> instance
/// </param>
/// <param name="hashingService">
/// The <see cref="IHashingService"/> instance
/// </param>
/// <param name="unitOfWork">
/// The <see cref="IUnitOfWOrk"/> instance
/// </param>
public class UserCommandService(
    IUserRepository userRepository,
    ITokenService tokenService,
    IHashingService hashingService,
    IUnitOfWOrk unitOfWork
    ) : IUserCommandService
{
    // <inheritdoc/>
    public async Task Handle(SignUpCommand command)
    {
        if (userRepository.ExistsByUsername(command.Username))
            throw new Exception($"Username {command.Username} already exists");

        var hashedPassword = hashingService.HashPassword(command.Password);
        var user = new User(command.Username, hashedPassword, command.Role);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating the user: {e.Message}");
        }
    }

    // <inheritdoc/>
    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByUsernameAsync(command.Username);
        if (user is null) throw new Exception($"User {command.Username} not found");
        if (!hashingService.VerifyPassword(command.Password, user.PasswordHash))
            throw new Exception("Invalid password");
        var token = tokenService.GenerateToken(user);
        return (user, token);
    }
}