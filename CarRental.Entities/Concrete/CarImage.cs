using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.Concrete
{
    public class CarImage : EntityBase
    {
        public int CarId { get; set; }
        public virtual Car Car { get; set; }
        public string ImagePath { get; set; }
    }
}
