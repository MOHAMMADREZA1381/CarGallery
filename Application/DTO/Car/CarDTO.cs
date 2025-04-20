using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.DTO.Car
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int YearCar { get; set; }
        public string VinCar { get; set; }
        public string CarBrand { get; set; }
        public float Price { get; set; }
        public CarState CarState { get; set; }
        public List<string> imagepath { get; set; } = new List<string>();
    }
}
