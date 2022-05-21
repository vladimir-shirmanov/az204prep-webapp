using Az204.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Az204.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public FilesController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromForm] FileModel file)
        {
            if(file.File == null)
            {
                return BadRequest("Please send us a file");
            }

            string path = Path.Combine(_env.WebRootPath, "docs", Guid.NewGuid().ToString());
            using var stream = new FileStream(path, FileMode.Create);
            await file.File.CopyToAsync(stream);
            return Ok($"Processed doc {file.Title} v{file.Version} - {file.File.FileName}");
        }
    }
}
