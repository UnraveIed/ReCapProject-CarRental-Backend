using CarRental.Business.Abstract;
using CarRental.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getallwithbrandanduser")]
        public async Task<IActionResult> GetAllWithBrandAndUser()
        {
            var result = await _rentalService.GetAllWithBrandAndUserAsync();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _rentalService.GetAllAsync();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int rentalId)
        {
            var result = await _rentalService.GetByIdAsync(rentalId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Rental entity)
        {
            var result = await _rentalService.AddAsync(entity);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int rentalId)
        {
            var brand = await _rentalService.GetByIdAsync(rentalId);
            if (brand.IsSuccess)
            {
                var result = await _rentalService.HardDeleteAsync(brand.Data);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(brand);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Rental entity)
        {
            var result = await _rentalService.UpdateAsync(entity);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("rentcar")]
        public async Task<IActionResult> RentCar(int rentId, int code)
        {
            var result = await _rentalService.RentAsync(rentId, code);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
