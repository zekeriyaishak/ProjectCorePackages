using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CorePackagesGeneral.Utilities.Storage.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePackagesGeneral.Utilities.Storage.Concrete
{
    public class AzureBlobManager : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _contentType = "application/octet-stream";

        public AzureBlobManager(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task DeleteBlobAsync(string containerName, string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.DeleteIfExistsAsync();
        }

        public async Task<BlobInfo> GetBlobInfoAsync(string containerName, string name)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(name);
            var blobDownloadInfo = await blobClient.DownloadAsync();

            return new BlobInfo(blobDownloadInfo.Value.Content, blobDownloadInfo.Value.ContentType);
        }

        public async Task<string> UploadBlobAsync(string containerName, IFormFile formFile)
        {
            var fileName = await UploadBlobToContainer(containerName,formFile);
            return fileName;
        }

        public async Task<List<string>> UploadMultipleBlobsAsync(string containerName, List<IFormFile> formFiles)
        {
            var fileNames = new List<string>();
            foreach (var formFile in formFiles)
            {
                var file = await UploadBlobToContainer(containerName,formFile);
                fileNames.Add(file);
            }
            return fileNames;
        }

        #region Private Method
        private async Task<string> UploadBlobToContainer(string containerName, IFormFile formFile)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var guid = Guid.NewGuid();
            var fileName = string.Concat(guid.ToString(), Path.GetExtension(formFile.FileName));
            try
            {
                var blobClient = containerClient.GetBlobClient(fileName);
                using Stream stream = formFile.OpenReadStream();
                await blobClient.UploadAsync(stream, new BlobHttpHeaders {ContentType = formFile.ContentType ?? _contentType });
            }
            catch (Exception ex)
            {
                throw new Exception("Kaydedilirken azure hata oluştu: ", ex);
            }
            return fileName;
        }


        #endregion
    }
}
