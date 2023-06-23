using CarRental.Entities.ComplexTypes;
using CarRental.Entities.Dtos;
using Core.Utilities.Results.Abstract;

namespace CarRental.MVC.UI.Helpers.Abstract
{
    public interface IImageHelper
    {
        Task<IDataResult<ImageUploadedDto>> UploadAsync(IFormFile pictureFile, PictureType pictureType, string folderName = null, string fileName = null);
        Task<IDataResult<ImageUploadedDto>> UpdateAsync(string imagePath, IFormFile pictureFile, PictureType pictureType, string folderName = null, string fileName = null);
        IDataResult<ImageDeletedDto> Delete(string pictureName);
    }
}
