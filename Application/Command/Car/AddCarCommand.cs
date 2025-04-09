using System;
using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Application.Command.Car;

public class AddCarCommand
{
    public string CarBrand { get; set; }
    public float Price { get; set; }
    public string VinCar { get; set; }
    public string Color{ get; set; }
    public int YearCar{ get; set; }
    public CarState State{ get; set; }
    public ICollection<IFormFile>? Carimgs{ get; set; }
}