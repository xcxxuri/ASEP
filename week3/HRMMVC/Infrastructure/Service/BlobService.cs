using System;
using ApplicationCore.Contract.Services;
using ApplicationCore.Models;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Infrastructure.Service
{
	public class BlobService: IBlobService
	{
        private readonly BlobServiceClient _blobServiceClient;
        private readonly BlobContainerClient _blobContainerClient;
        
		public BlobService( BlobServiceClient blobServiceClient, BlobContainerClient blobContainerClient)
		{
            _blobServiceClient = blobServiceClient;
            _blobContainerClient = blobContainerClient;
		}

        public async Task DeleteBlobAsync(string blobName)
        {
            var blobClient = _blobContainerClient.GetBlobClient(blobName);
            await blobClient.DeleteIfExistsAsync();
        }

        public async Task<BlobResponseModel> GetBlobAsync(string name)
        {
            var blobClient = _blobContainerClient.GetBlobClient(name);
            var blobDownloadResult = await blobClient.DownloadAsync();
            
            return new BlobResponseModel(blobDownloadResult.Value.Content, blobDownloadResult.Value.Details.ContentType);
        }

        public async Task<IEnumerable<string>> ListBlobsAsync()
        {
            var items = new List<string>();

            await foreach (var blobItem in _blobContainerClient.GetBlobsAsync())
            {
                items.Add(blobItem.Name);
            }

            return items;
        }

        public async Task UploadFileBlobAsync(string filePath, string fileName)
        {
            var blobClient = _blobContainerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(filePath);
        }
    }
}

