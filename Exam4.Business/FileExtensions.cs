using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Exam4.Business
{
    public static class FileExtensions
    {
        public const string InstructorImageFolder = "instructhorimages";

        public static async Task<string> SaveAndRetrievePathAsync(this IFormFile file,IWebHostEnvironment env)
        {

            var webRootFolder = env.WebRootPath;

            var imageFolderPath = Path.Combine(webRootFolder,InstructorImageFolder);

            if(!Directory.Exists(imageFolderPath))
                Directory.CreateDirectory(imageFolderPath);

            var imageName = Guid.NewGuid().ToString()+file.FileName;

            var newFilePath = Path.Combine(imageFolderPath,imageName);

            using (var newfile = File.Create(newFilePath))
            { 
                await file.CopyToAsync(newfile);
            }
              
            return Path.Combine(InstructorImageFolder,imageName);
        }

    }
}
