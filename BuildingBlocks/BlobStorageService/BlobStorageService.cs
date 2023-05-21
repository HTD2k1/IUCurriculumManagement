
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using BlobStorageService.Helpers;
namespace BlobStorageService
{
    public class BlobStorageService: IBlobStorageService
    {
        // TO DO: Move all hard coded token to local host configuration, add dependency injection instead of default injection
        private static readonly string _storageEndpoint = "https://nccognitivestorage.blob.core.windows.net/";
        private static readonly string _sasString = "?sv=2021-08-06&ss=b&srt=sco&st=2022-12-12T03%3A55%3A24Z&se=2023-12-13T03%3A55%3A00Z&sp=rwdlacu&sig=pZ93L7z7aopkF9H7vILp3u%2B%2BEw3pXG4UkfGUOy51Lu4%3D";
        private static readonly string _sourceContainer = "source-container";

        // Initialize blob storage client 
        private static Azure.AzureSasCredential _sasCredential = new Azure.AzureSasCredential(_sasString);
        private static Uri _blobServiceUri = new Uri(_storageEndpoint);
        private static BlobServiceClient _storageService = new BlobServiceClient(_blobServiceUri, _sasCredential);
        private static BlobContainerClient _sourceContainerClient = _storageService.GetBlobContainerClient(_sourceContainer);

        public async Task UploadFileToAzureBlobStorageAsync(IFormFile file)
        {
            BlobClient blobClient = _sourceContainerClient.GetBlobClient(file.FileName);
            var fileStream = file.OpenReadStream();
            await blobClient.UploadAsync(fileStream, overwrite: true);
            fileStream.Close();
        }

        public async Task<Stream> DownloadAzureBlobStreamingAsync(string fileName)
        {
            BlobClient blobClient =  _sourceContainerClient.GetBlobClient(fileName);
            var response = await blobClient.DownloadStreamingAsync();
            return response.Value.Content;
        }
    }
}
