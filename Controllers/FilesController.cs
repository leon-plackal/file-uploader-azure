using file_uploader_azure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace file_uploader_azure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly BlobService _blobService;
        public FilesController(BlobService blobService)
        {
            _blobService = blobService;
        }

        [HttpPost("upload")]
        [Authorize]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            await _blobService.UploadFileAsync("uploads", stream, file.FileName);
            return Ok("File uploaded successfully.");
        }
    }

}
