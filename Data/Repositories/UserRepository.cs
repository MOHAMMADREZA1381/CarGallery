using System.Data;
using Dapper;
using Domain.IRepositories;
using Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Data.Repositories;

public class UserRepository : IUserRepository
{
    private IDbConnection _connection;

    public UserRepository(IConfiguration configuration)
    {
        _connection = new SqlConnection(configuration.GetConnectionString("CarGalley"));
    }

    public async Task AddUser(User user)
    {
        string query = "Insert Into Users (FullName,Email,Password) Values(@FullName,@Email,@Password)";
        _connection.ExecuteAsync(query, new { FullName = user.FullName, Email = user.Email, Password = user.Password });
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
}