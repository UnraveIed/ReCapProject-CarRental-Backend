using CarRental.Business.Abstract;
using CarRental.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _brandService.GetAllAsync();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid/{brandId}")]
        public async Task<IActionResult> GetById([FromRoute]int brandId)
        {
            var result = await _brandService.GetById(brandId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] Brand entity)
        {
            var result = await _brandService.AddAsync(entity);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] int brandId)
        {
            var brand = await _brandService.GetById(brandId);
            if (brand.IsSuccess)
            {
                var result = await _brandService.HardDeleteAsync(brand.Data);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(brand);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] Brand entity)
        {
            var result = await _brandService.UpdateAsync(entity);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpDelete("delete")]
        //public async Task<IActionResult> Delete([FromBody] int brandId)
        //{
        //    var brand = await _brandService.GetById(brandId);
        //    if (brand.IsSuccess)
        //    {
        //        var result = await _brandService.HardDeleteAsync(brand.Data);
        //        if (result.IsSuccess)
        //        {
        //            return Ok(result);
        //        }
        //        return BadRequest(result);
        //    }
        //    return BadRequest(brand);
        //}
    }
}
