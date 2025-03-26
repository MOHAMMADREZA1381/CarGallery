using Domain.Models;

namespace Domain.IRepositories;

public interface IUserRepository
{
    Task AddUser(User user);
    Task<bool> CheckEmailExist(string email);
    Task<User> GetUserByEmail(string email);
}