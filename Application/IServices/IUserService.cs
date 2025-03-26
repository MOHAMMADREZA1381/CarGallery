using Application.Command.User;
using Application.DTO.User;

namespace Application.IServices;

public interface IUserService
{
    Task<StateOfRegister> RegisterAsync(RegisterUserCommand command);
    Task<StateOfLogin> LoginAsync(LoginUserCommand loginUserCommand);
    Task<UserIdDTO> GetUserIdByEmail(string email);
}