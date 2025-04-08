﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CarImg
    {
        public int Id{ get; set; }
        public string Img{ get; set; }
        public int CarId{ get; set; }
        [ForeignKey("CarId")]
        public Car Car{ get; set; }
    }
}
