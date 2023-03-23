using CarRental.Business.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.Dtos;
using CarRental.WebAPI.Helpers.Abstract;
using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private readonly ICarImageService _carImageService;
        private readonly IImageHelper _imageHelper;

        public CarImagesController(ICarImageService carImageService, IImageHelper imageHelper)
        {
            _carImageService = carImageService;
            _imageHelper = imageHelper;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _carImageService.GetAllAsync();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int carImageId)
        {
            var result = await _carImageService.GetById(carImageId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbycarid")]

        public async Task<IActionResult> GetAllByCarId(int carId)
        {
            var result = await _carImageService.GetAllByCarId(carId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add([FromForm] CarImageUploadDto model)
        {
            var imageResult = await _imageHelper.UploadAsync(model.ImageFile, Entities.ComplexTypes.PictureType.CarImage);
            if (imageResult.IsSuccess)
            {
                var addedCarImage = await _carImageService.AddAsync(new CarImage
                {
                    CarId = model.CarId,
                    ImagePath = imageResult.Data.FullName,
                });
                return Ok(addedCarImage);
            }
            return BadRequest(imageResult);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] CarImageUpdateDto model)
        {
            var carImage = await _carImageService.GetById(model.Id);
            IDataResult<CarImage> updateResult;
            if (carImage.IsSuccess)
            {
                string oldCarImagePath = carImage.Data.ImagePath;
                if (model.CarId.HasValue) carImage.Data.CarId = model.CarId.Value;
                if (model.ImageFile != null)
                {
                    var imageResult = await _imageHelper.UpdateAsync(oldCarImagePath, model.ImageFile, Entities.ComplexTypes.PictureType.CarImage, null, model.ImageFile.FileName);
                    if (imageResult.IsSuccess)
                    {
                        carImage.Data.ImagePath = imageResult.Data.FullName;
                        updateResult = await _carImageService.UpdateAsync(carImage.Data);
                        if (updateResult.IsSuccess)
                        {
                            return Ok(updateResult);
                        }
                        return BadRequest(updateResult);
                    }
                    return BadRequest(imageResult);
                }
                updateResult = await _carImageService.UpdateAsync(carImage.Data);
                if (updateResult.IsSuccess)
                {
                    return Ok(updateResult);
                }
                return BadRequest(updateResult);
            }
            return BadRequest(carImage);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int carImageId)
        {
            var carImage = await _carImageService.GetById(carImageId);
            Core.Utilities.Results.Abstract.IResult result;        
            if (carImage.IsSuccess)
            {
                if (carImage.Data.ImagePath != null)
                {
                    var deleteImage = _imageHelper.Delete(carImage.Data.ImagePath);
                    if (deleteImage.IsSuccess)
                    {
                        result = await _carImageService.HardDeleteAsync(carImage.Data);
                        if (result.IsSuccess)
                        {
                            return Ok(result);
                        }
                        return BadRequest(result);
                    }
                    return BadRequest(deleteImage);
                }
                result = await _carImageService.HardDeleteAsync(carImage.Data);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(carImage);
        }
    }
}
