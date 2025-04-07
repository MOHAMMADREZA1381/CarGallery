using System.Data;
using Dapper;
using Domain.IRepositories;
using Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbConnection _connection;

    public UserRepository(IConfiguration configuration)
    {
        _connection = new SqlConnection(configuration.GetConnectionString("CarGalley"));
    }

    public async Task AddUser(User user)
    {
        string query = "Insert Into Users (FullName,Email,Password) Values(@FullName,@Email,@Password)";
        await _connection.ExecuteAsync(query, 
            new
            {
                FullName = user.FullName,
                Email = user.Email,
                Password = user.Password
            });
    }

    public async Task<bool> CheckEmailExist(string email)
    {
        string query = @"SELECT u.Email FROM Users AS u " +
                       "WHERE u.Email = @Email";
        var resualt = _connection.QueryFirstOrDefaultAsync<User>(query, new { Email = email });
        return resualt.Result != null;
    }

    public async Task<User> GetUserByEmail(string email)
    {
        var quey = @"SELECT u.* FROM Users AS u WHERE u.Email=@Email";
        var User = _connection.QueryFirstOrDefaultAsync<User>(quey, new { Email = email });
        return User.Result;
    }

    public async Task ChangePassword(int Id, string Password)
    {
        var quet = @"Update Users Set Password=@Password Where Id=@Id";
        await _connection.ExecuteAsync(quet, new { Id = Password, Password = Password });
    }

    public async Task ChangeUserLevel(int Id, int Level)
    {
        var quet = @"Update Users Set Level=@Level Where Id=@Id";
        await _connection.ExecuteAsync(quet, new {Id=Id,Level=Level });
    }

    public async Task<string> GenerateOtp(int Id,string OTP)
    {
        var query = @"Update Users Set OTP=@OTP Where Id=@Id ";
        await _connection.ExecuteAsync(query, new {Id=Id,OTP=OTP });
        return OTP;
    }
}