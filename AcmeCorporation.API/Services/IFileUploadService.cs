using System.Collections.Generic;
using AcmeCorporation.API.Data.Models;
using Microsoft.AspNetCore.Http;

namespace AcmeCorporation.API.Services
{
    public interface IFileUploadService
    {
        IList<Photo> UploadFiles(IList<IFormFile> files);
        IList<string> GetPhysicalPathFromRelativeUrl(IList<string> urls);
    }
}