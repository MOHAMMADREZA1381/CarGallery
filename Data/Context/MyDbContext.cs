using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {

    }


    public DbSet<User> Users { get; set;}
    public DbSet<CarImg> CarImgs { get; set; }
    public DbSet<Car> Cars{ get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

}