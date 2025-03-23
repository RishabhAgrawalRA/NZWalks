using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        //POST /api/Images/Upload
        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDTO imageUploadRequestDTO)
        {
            //Validte Image
            ValidateImageUpload(imageUploadRequestDTO);

            if (ModelState.IsValid)
            {
                //Conver ImageUpload DTO to Image Domain
                var image = new Image
                {
                    File = imageUploadRequestDTO.File,
                    FileName = imageUploadRequestDTO.FileName,
                    FileDescription = imageUploadRequestDTO.FileDescription,
                    FileExtension = Path.GetExtension(imageUploadRequestDTO.File.FileName),
                    FileSizeInBytes = imageUploadRequestDTO.File.Length,
                };

                // Repository to Uplaod
                await imageRepository.Upload(image);
                return Ok(image);
            }

            return BadRequest(ModelState);
        }

        private void ValidateImageUpload(ImageUploadRequestDTO imageUploadRequestDTO) 
        {
            var allowedExtension = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtension.Contains(Path.GetExtension(imageUploadRequestDTO.File.FileName)))
                ModelState.AddModelError("File", "Unsupported File Extension, pls use jpeg/jpg/png");

            if (imageUploadRequestDTO.File.Length > 10485760)
                ModelState.AddModelError("File", "File size more than 10mb, pls upload small size file");
        }
    }
}
