using CarRental.Entities.ComplexTypes;
using CarRental.Entities.Dtos;
using CarRental.MVC.UI.Helpers.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using System.Text.RegularExpressions;

namespace CarRental.MVC.UI.Helpers.Concrete
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _environment;
        private readonly string _baseFolderName;
        private readonly string _wwwroot;

        public ImageHelper(IWebHostEnvironment environment)
        {
            _environment = environment;
            _wwwroot = _environment.WebRootPath;
            _baseFolderName = "images";
        }

        

        public IDataResult<ImageDeletedDto> Delete(string pictureName)
        {
            var result = IsFileExist(pictureName);

            if (result)
            {
                string fileToDelete = $"{_wwwroot}/{_baseFolderName}/{pictureName}";
                var fileInfo = new FileInfo(fileToDelete);
                var imageDeletedDto = new ImageDeletedDto
                {
                    FullName = pictureName,
                    Extension = fileInfo.Extension,
                    Path = fileInfo.FullName,
                    Size = fileInfo.Length
                };
                System.IO.File.Delete(fileToDelete);
                return new SuccessDataResult<ImageDeletedDto>(imageDeletedDto);
            }
            return new ErrorDataResult<ImageDeletedDto>();
        }

        public async Task<IDataResult<ImageUploadedDto>> UploadAsync(IFormFile pictureFile, PictureType pictureType, string folderName = null, string fileName = null)
        {
            folderName = GetFolderName(pictureType);

            IsDirectoryExist(folderName);

            fileName ??= Path.GetFileNameWithoutExtension(pictureFile.FileName);

            string fileExtension = Path.GetExtension(pictureFile.FileName);

            fileName = RegexControl(fileName);

            string newFileName = CreateGuidDateTime(fileName, fileExtension);

            var path = Path.Combine(_wwwroot,_baseFolderName,folderName,newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await pictureFile.CopyToAsync(fileStream);
            }

            return new SuccessDataResult<ImageUploadedDto>(new ImageUploadedDto
            {
                FullName = $"{folderName}/{newFileName}",
                Extension = fileExtension,
                FolderName = folderName,
                Path = path,
                Size = pictureFile.Length
            }, "Başarıyla yüklendi");

        }


        public async Task<IDataResult<ImageUploadedDto>> UpdateAsync(string imagePath, IFormFile pictureFile, PictureType pictureType, string folderName = null, string fileName = null)
        {
            Delete(imagePath);
            return await UploadAsync(pictureFile,pictureType,folderName,fileName);
        }


        private void IsDirectoryExist(string folderName)
        {
            var result = Directory.Exists($"{_wwwroot}/{_baseFolderName}/{folderName}");
            if (!result)
            {
                Directory.CreateDirectory($"{_wwwroot}/{_baseFolderName}/{folderName}");
            }
        }

        private bool IsFileExist(string pictureName)
        {
            var fileToDelete = Path.Combine($"{_wwwroot}/{_baseFolderName}/", pictureName);
            var result = System.IO.File.Exists(fileToDelete);
            return result;
        }

        private string RegexControl(string fileName)
        {
            Regex regex = new Regex("[*'\",._&#^@]");
            fileName = regex.Replace(fileName, string.Empty);
            return fileName;
        }

        private string CreateGuidDateTime(string fileName, string extension)
        {
            DateTime dateTime = DateTime.Now;

            return $"{fileName}_{dateTime.Millisecond}_{dateTime.Second}_{dateTime.Minute}_{dateTime.Hour}_{dateTime.Day}_{dateTime.Month}_{dateTime.Year}_{extension}";
        }

        private string GetFolderName(PictureType pictureType)
        {
            switch (pictureType)
            {
                case PictureType.CarImage:
                    return "carImages";
                default:
                    return "default";
            }
        }
    }
}
