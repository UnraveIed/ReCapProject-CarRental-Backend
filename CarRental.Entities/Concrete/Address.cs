using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.Concrete
{
    public class Address : EntityBase
    {
        public string AddressTitle { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string AddressDesc { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
