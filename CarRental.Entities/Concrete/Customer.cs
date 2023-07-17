using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.Concrete
{
    public class Customer : EntityBase
    {
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Rental>? Rentals { get; set; }
        public int FindexPoint { get; set; }
        public virtual ICollection<Address>? Addresses { get; set; }
    }
}
