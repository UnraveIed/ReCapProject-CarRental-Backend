using CarRental.Entities.Concrete;
using CarRental.Entities.Dtos;
using Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Abstract
{
    public interface ICarRepository : IEntityRepositoryBase<Car>
    {
        Task<List<CarDetailDto>> GetCarDetail();
    }
}
