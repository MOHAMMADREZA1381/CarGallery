using Domain.Models;

namespace Domain.IRepositories;

public interface ICarRepository
{
    Task<int> AddCar(Car car);
    Task EditCar(Car car);
    Task DeleteCar(int Id);
    Task<Car> GetCarById(int Id);
    Task<ICollection<Car>> GetAllCars();
    Task AddImgToCar(CarImg img);
}