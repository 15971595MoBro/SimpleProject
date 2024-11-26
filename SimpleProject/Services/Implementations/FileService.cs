using SimpleProject.Services.Interfaces;

namespace SimpleProject.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public bool DeletePhysicalFile(string path)
        {
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + path);
            if (File.Exists(directoryPath)) { 
                File.Delete(directoryPath);
                return true;
            }
            return false;
        }

        public async Task<string> Upload(IFormFile file , string location)
        {

                try
                {

                    var path = _webHostEnvironment.WebRootPath + location;
                    var extension = Path.GetExtension(file.FileName);
                    var filename = Guid.NewGuid().ToString().Replace("-", String.Empty) + extension;
                    //Save
                    if (!Directory.Exists(path)) { 
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = File.Create(path + filename)) {
                        await file.CopyToAsync(fileStream);
                        fileStream.Flush();
                        return $"{location}/{filename}";
                    }
                }
                catch
                {
                    return "Problem";
                }
            
        }
    }
}
