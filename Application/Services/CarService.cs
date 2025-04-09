using Application.Command.Car;
using Application.ImageTools;
using Application.ImageTools.Common;
using Application.IServices;
using Domain.IRepositories;
using Domain.Models;

namespace Application.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _repository;
    public CarService(ICarRepository repository)
    {
        _repository = repository;
    }


    public async Task AddCar(AddCarCommand command)
    {
        var car = new Car(command.CarBrand, command.YearCar, command.Color, command.Price, command.VinCar, command.State);
        var carId = await _repository.AddCar(car);
        foreach (var item in command.Carimgs)
        {
            if (item.Length > 0)
            {
                var galleryImage = "";
                galleryImage = Guid.NewGuid().ToString("N") + Path.GetExtension(item.FileName);
                item.AddImageToServer(galleryImage, PathExtensions.CarOrginServer, 300, 300, PathExtensions.CarThumbServer);
                var img = new CarImg(galleryImage, carId);
                await _repository.AddImgToCar(img);
            }
        }
    }

    public Task EditCar(Car car)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCar(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<Car> GetCarById(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Car>> GetAllCars()
    {
        throw new NotImplementedException();
    }

    public async Task AddCatImg(int CarId, string Path)
    {
        var img = new CarImg(Path, CarId);
        await _repository.AddImgToCar(img);
    }
}