using CarRental.Business.Abstract;
using CarRental.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("getallbycustomer")]
        public async Task<IActionResult> GetAllByCustomerId([FromQuery] int customerId)
        {
            var addresses = await _addressService.GetAllByCustomerIdAsync(customerId);
            if(!addresses.IsSuccess)
                return BadRequest(addresses);
            return Ok(addresses);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById([FromQuery(Name = "addressId")] int addressId)
        {
            var address = await _addressService.GetById(addressId);
            if(!address.IsSuccess)
                return BadRequest(address);
            return Ok(address);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAddress([FromBody] Address address)
        {
            var result = await _addressService.AddAsync(address);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("addaddresses")]
        public async Task<IActionResult> AddAddresses([FromBody] Address[] addresses)
        {
            var result = await _addressService.AddRangeAsync(addresses);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAddress([FromBody] Address address)
        {
            var result = await _addressService.UpdateAsync(address);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAddress([FromQuery(Name = "addressId")] int addressId)
        {
            var result = await _addressService.HardDeleteAsync(addressId);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
