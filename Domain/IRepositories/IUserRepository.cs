using Domain.Models;

namespace Domain.IRepositories;

public interface IUserRepository
{
    Task AddUser(User user);
    Task<bool> CheckEmailExist(string email);
    Task<User> GetUserByEmail(string email);
    Task ChangePassword(int UserId,string Password);
    Task ChangePasswordWithOtp(int UserId, string Password);
    Task ChangeUserLevel(int UserId, int Level);
    Task<string> GenerateOtp(int UserId,string OTP);
    Task<User> GetUserById(int Id);
}