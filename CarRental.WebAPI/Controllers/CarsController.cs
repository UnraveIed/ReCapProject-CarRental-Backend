using CarRental.Business.Abstract;
using CarRental.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getallwithbrandandcolor")]
        public async Task<IActionResult> GetAllWithBrandAndColor(int? brandId, int? colorId)
        {
            var result = await _carService.GetCarWithColorAndBrand(brandId, colorId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _carService.GetAllAsync();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallcardetail")]
        public async Task<IActionResult> GetAllCarDetail()
        {
            var result = await _carService.GetAllCarDetail();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetail")]
        public async Task<IActionResult> GetCarDetail(int carId)
        {
            var result = await _carService.GetCarDetailAsync(carId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int carId)
        {
            var result = await _carService.GetByIdAsync(carId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Car entity)
        {
            var result = await _carService.AddAsync(entity);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int carId)
        {
            var brand = await _carService.GetByIdAsync(carId);
            if (brand.IsSuccess)
            {
                var result = await _carService.HardDeleteAsync(brand.Data);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(brand);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Car entity)
        {
            var result = await _carService.UpdateAsync(entity);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarwithcolorsandbrands")]
        public async Task<IActionResult> GetCarWithColorsAndBrands([FromQuery] int[] colorIds, [FromQuery] int[] brandIds)
        {
            var result = await _carService.GetCarWithColorsAndBrands(colorIds, brandIds);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
