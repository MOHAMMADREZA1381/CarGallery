using Application.IServices;
using Application.Services;
using Data.Repositories;
using Domain.IRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace IOC.Container;

public class DependencyContainer
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<ICarService, CarService>();


    }
}