using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.Concrete
{
    public class Car : EntityBase
    {
        // Brand 1-n
        public int BrandId { get; set; }
        public virtual Brand? Brand { get; set; }

        // Color 1-n
        public int ColorId { get; set; }
        public virtual Color? Color { get; set; }

        // Rental N
        public virtual ICollection<Rental>? Rentals { get; set; }

        // CarImages N
        public virtual ICollection<CarImage>? CarImages { get; set; }

        public short ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
