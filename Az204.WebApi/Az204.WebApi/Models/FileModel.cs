namespace Az204.WebApi.Models
{
    public class FileModel
    {
        public string? Title { get; set; }

        public string? Version { get; set; }

        public IFormFile? File { get; set; }
    }
}
