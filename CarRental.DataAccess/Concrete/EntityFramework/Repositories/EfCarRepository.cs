using CarRental.DataAccess.Abstract;
using CarRental.DataAccess.Concrete.EntityFramework.Contexts;
using CarRental.Entities.Concrete;
using CarRental.Entities.Dtos;
using Core.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfCarRepository : EfEntityRepositoryBase<Car, CarRentalContext>, ICarRepository
    {

        public async Task<List<CarDetailDto>> GetCarDetail()
        {
            using (var context = new CarRentalContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice
                             };
                var res = await result.ToListAsync();
                return res;
            }
        }
    }
}
