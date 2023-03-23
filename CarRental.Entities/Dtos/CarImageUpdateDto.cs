using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.Dtos
{
    public class CarImageUpdateDto
    {
        //Car image id
        public int Id { get; set; }
        public int? CarId { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
