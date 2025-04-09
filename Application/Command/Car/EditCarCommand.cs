using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Application.Command.Car
{
    public class EditCarCommand
    {
        public int Id { get;  set; }

      
        public string CarBrand { get;  set; }


        public int YearCar { get;  set; }

       
        public string Color { get;  set; }

        public float Price { get;  set; }

       
        public string VinCar { get;  set; }
        public CarState CarState { get;  set; }

        public ICollection<IFormFile>? CarImgs { get; set; }
    }
}
