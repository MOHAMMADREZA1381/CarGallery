using Dapper;
using Data.Context;
using Domain.IRepositories;
using Domain.Models;
using System.Drawing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Data.Repositories;

public class CarRepository : ICarRepository
{
    #region Context



    private readonly MyDbContext _context;
    public CarRepository(MyDbContext context)
    {
        _context = context;
    }
    #endregion

    public async Task<int> AddCar(Car car)
    {
        var query =
            @"Insert Into Cars (CarBrand,YearCar,Color,Price,VinCar,CarState) output inserted.Id Values (@CarBrand,@YearCar,@Color,@Price,@VinCar,@CarState)";
        return await _context._Dapper.ExecuteAsync(query, new
        {
            CarBrand = car.CarBrand,
            YearCar = car.YearCar,
            Color = car.Color,
            Price = car.Price,
            VinCar = car.VinCar,
            CarState = car.CarState,
        });
    }

    public async Task EditCar(Car car)
    {
        var query = @"Update Cars Set CarBrand=@CarBrand,YearCar=@YearCar,Color=@Color,Price=@Price,VinCar=@VinCar,CarState=@CarState,CarImgs=@CarImgs Where Id=@Id";
        await _context._Dapper.ExecuteAsync(query, new
        {
            CarBrand = car.CarBrand,
            YearCar = car.YearCar,
            Color = car.Color,
            Price = car.Price,
            VinCar = car.VinCar,
            CarState = car.CarState,
            CarImgs = car.CarImgs
        });
    }

    public async Task DeleteCar(int Id)
    {
        var query = @"Delete From Cars Where Id=@Id";
        await _context._Dapper.ExecuteAsync(query, new { Id = Id });
    }

    public async Task<Car> GetCarById(int Id)
    {
        var query = @"Select c.*,i.img From Cars AS c  " +
                   "Join CarImgs i ON i.CarId=c.Id " +
                   "Where c.Id=@Id";

        var Car = _context._Dapper.QueryAsync<Car, CarImg, Car>(query, (c, i) =>
        {
            if (c.CarImgs != null)
            {
                if (c.CarImgs == null)
                {
                    c.CarImgs = new List<CarImg>();
                }
                c.CarImgs.Add(i);
            }

            return c;
        },new { Id = Id },splitOn:"Img").Result.FirstOrDefault();
        return Car;
    }

    public async Task<ICollection<Car>> GetAllCars()
    {
        var query = @"SELECT car.*,img.Img FROM Cars AS car " +
                    "JOIN CarImgs img ON img.CarId=car.Id";
        var carListWithImages = _context._Dapper.QueryAsync<Car, CarImg, Car>(query, (car, img) =>
        {
            if (img != null)
            {
                if (car.CarImgs == null)
                {
                    car.CarImgs = new List<CarImg>();
                }
                car.CarImgs.Add(img);
            }
            return car;
        }, splitOn: "Img").Result.ToList();
        return carListWithImages;
    }

    public async Task AddImgToCar(CarImg img)
    {
        var query = @"Insert Into CarImgs (Img,CarId) Values (@Img,@CarId)";
        await _context._Dapper.QueryAsync(query, new { Img = img.Img, CarId = img.CarId });
    }
}