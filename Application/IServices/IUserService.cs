using Application.Command.User;
using Application.DTO.User;
using Application.ExtentionsMethode;

namespace Application.IServices;

public interface IUserService
{
    Task<StateOfRegister> RegisterAsync(RegisterUserCommand command);
    Task<StateOfLogin> LoginAsync(LoginUserCommand loginUserCommand);
    Task<UserIdDTO> GetUserIdByEmail(string email);
    Task ChangePassword(int UserId,string Password);
}