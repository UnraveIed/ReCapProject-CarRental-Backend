using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.Concrete
{
    public class Rental : EntityBase
    {
        public int CarId { get; set; }
        public virtual Car? Car { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
