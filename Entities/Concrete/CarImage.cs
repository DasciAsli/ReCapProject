﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CarImage:IEntity
    {
        public int CarImageId { get; set; }
        public int CarId { get; set; }
        public string? ImagePath { get; set; } //Null ataması yapılabilmesi için ? kullanıldı.
        public DateTime Date { get; set; }
    }
}
