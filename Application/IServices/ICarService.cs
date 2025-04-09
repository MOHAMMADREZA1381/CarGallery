using Application.Command.Car;
using Domain.Models;

namespace Application.IServices;

public interface ICarService
{

    Task AddCar(AddCarCommand car);
    Task EditCar(Car car);
    Task DeleteCar(int Id);
    Task<Car> GetCarById(int Id);
    Task<ICollection<Car>> GetAllCars();
    Task AddCatImg(int CarId,string Path);
}