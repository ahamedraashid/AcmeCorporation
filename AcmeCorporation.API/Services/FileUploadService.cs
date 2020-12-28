using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AcmeCorporation.API.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace AcmeCorporation.API.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IConfiguration _configuration;
        public FileUploadService(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
        public IList<Photo> UploadFiles(IList<IFormFile> files)
        {
            var images = new List<Photo>();
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        //Getting FileName
                        var fileName = Path.GetFileName(file.FileName);

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);
                        var folder = _configuration.GetSection("FileStore:Images").Value;

                        // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);
                        var projectDir = _configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
                        // var projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

                        // Combines two strings into a path.
                        var filepath = Path.Combine(projectDir, folder, newFileName);

                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }

                        images.Add(new Photo
                        {
                            Filename =  Path.Combine(folder, newFileName)
                        });

                    }
                }
            }
            return images;
        }

         public IList<string> GetPhysicalPathFromRelativeUrl(IList<string> urls)
        {
            var physicalPaths = new List<string>();
            var folder = _configuration.GetSection("FileStore:Images").Value;
            var projectDir = _configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
            urls.ToList().ForEach(u =>
            {
                physicalPaths.Add(Path.Combine(projectDir, folder, u.TrimStart('/').Replace("/", "\\")));
            });

            return physicalPaths;
        }
    }
}