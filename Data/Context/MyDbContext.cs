using System.Data;
using Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Context;

public class MyDbContext : DbContext
{
    internal readonly IDbConnection _Dapper;
    public MyDbContext(DbContextOptions<MyDbContext> options,IConfiguration configuration) : base(options)
    {
        _Dapper = new SqlConnection(configuration.GetConnectionString("CarGalley"));
    }


    public DbSet<User> Users { get; set;}
    public DbSet<CarImg> CarImgs { get; set; }
    public DbSet<Car> Cars{ get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

}