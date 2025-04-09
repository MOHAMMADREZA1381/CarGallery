using Application.Command.Car;
using Application.DTO.Car;
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

  

    public async Task EditCar(EditCarCommand car)
    {
        var Car = await _repository.GetCarById(car.Id);
        Car.EditCar(car.CarBrand, car.YearCar, car.Color, car.Price, car.VinCar);
    }

    public async Task DeleteCar(int Id)
    {
        await _repository.DeleteCar(Id);
    }

    public Task<Car> GetCarById(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<CarDTO>> GetAllCars()
    {
      var AllCars = await _repository.GetAllCars(); 
        var cars = new List<CarDTO>();
        foreach (var car in AllCars)
        {
            var dto=new CarDTO();
            dto.CarBrand = car.CarBrand;
            dto.Color = car.Color;
            dto.Price = car.Price;
            dto.VinCar = car.VinCar;
            dto.YearCar = car.YearCar;
            dto.CarState = car.CarState;
            foreach (var item in car.CarImgs)
            {
                dto.imagepath.Add(item.Img);
            }
            cars.Add(dto);
        }

        return cars;
    }

    public async Task AddCatImg(int CarId, string Path)
    {
        var img = new CarImg(Path, CarId);
        await _repository.AddImgToCar(img);
    }
}