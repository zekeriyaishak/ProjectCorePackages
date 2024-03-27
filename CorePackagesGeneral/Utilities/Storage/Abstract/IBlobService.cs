using CorePackagesGeneral.Utilities.Storage.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePackagesGeneral.Utilities.Storage.Abstract
{
    public interface IBlobService
    {
        Task<BlobInfo> GetBlobInfoAsync(string containerName, string name);
        Task<string> UploadBlobAsync(string containerName, IFormFile formFile);
        Task<List<string>> UploadMultipleBlobsAsync(string containerName, List<IFormFile> formFiles);
        Task DeleteBlobAsync(string containerName, string fileName);
    }
}
