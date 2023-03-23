using CarRental.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface IColorService
    {
        Task<IDataResult<IList<Color>>> GetAllAsync();
        Task<IDataResult<Color>> AddAsync(Color entity);
        Task<IDataResult<Color>> UpdateAsync(Color entity);
        Task<IResult> HardDeleteAsync(Color entity);
        Task<IDataResult<Color>> GetByIdAsync(int colorId);
        Task<IDataResult<Color>> TransactionTest(Color entity); 
    }
}
