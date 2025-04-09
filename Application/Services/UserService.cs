using Application.Command.User;
using Application.DTO.User;
using Application.ExtentionsMethode;
using Application.IServices;
using Domain.IRepositories;
using Domain.Models;

namespace Application.Services;

public class UserService : IUserService
{

    #region Repo

    private readonly IUserRepository _repository;
    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }
    #endregion


    public async Task<StateOfRegister> RegisterAsync(RegisterUserCommand command)
    {
        var emailExist = await _repository.CheckEmailExist(command.Email);

        if (emailExist == true)
            return StateOfRegister.UserAlreadyExist;

        if (command.Password != command.ConfirmPassword)
            return StateOfRegister.WrongPassword;

        string password = PasswordHelper.EncodePasswordSha256(command.Password);
        var user = new User(command.Name, command.Email, password);
        await _repository.AddUser(user);
        return StateOfRegister.Success;
    }

    public async Task<StateOfLogin> LoginAsync(LoginUserCommand loginUserCommand)
    {
        var UserExist = await _repository.CheckEmailExist(loginUserCommand.Email);
        if (UserExist == false)
            return StateOfLogin.Failed;
        var User = await _repository.GetUserByEmail(loginUserCommand.Email);
        if (User.Password != PasswordHelper.EncodePasswordSha256(loginUserCommand.Password))
            return StateOfLogin.Failed;

        return StateOfLogin.Success;
    }

    public async Task<UserIdDTO> GetUserIdByEmail(string email)
    {
        var User = await _repository.GetUserByEmail(email);
        var DTO = new UserIdDTO()
        {
            Id = User.Id
        };
        return DTO;
    }

    public async Task ChangePassword(int UserId, string Password)
    {
       var User= await _repository.GetUserById(UserId);
       User.ChangePassword(PasswordHelper.EncodePasswordSha256(Password));
    }
}