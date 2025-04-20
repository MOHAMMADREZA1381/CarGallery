using Application.Command.Car;
using Application.DTO.Car;
using Domain.Models;

namespace Application.IServices;

public interface ICarService
{

    Task AddCar(AddCarCommand car);
    Task EditCar(EditCarCommand car);
    Task DeleteCar(int Id);
    Task<CarDTO> GetCarById(int Id);
    Task<ICollection<CarDTO>> GetAllCars();
    Task AddCatImg(int CarId,string Path);
}