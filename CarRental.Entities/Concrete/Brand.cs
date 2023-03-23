using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.Concrete
{
    public class Brand : EntityBase
    {
        public string Name { get; set; }

        // Cars N
        public virtual ICollection<Car>? Cars { get; set; }
    }
}
