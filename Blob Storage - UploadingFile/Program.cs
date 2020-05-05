using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Blob_Storage___UploadingFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=vishalstorageaccount;AccountKey=BWQ01j8aW8xCUIaCzA8Gn+5fdzJBz81i4//8x4u9ZUyQre6aRsszGR+hGMmTaKk+y5ajBPOaILXNtLAEFnDP/Q==;EndpointSuffix=core.windows.net";
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(StorageConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference("blobcontainer");

            blobContainer.CreateIfNotExistsAsync();
            CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference("demofile" + ".txt");
            Console.WriteLine("Uploading File");
            Uploadfile(blockBlob).Wait();
            Console.WriteLine("File Uploaded Successfully");
            Console.ReadLine();
        }
        private static async Task Uploadfile(CloudBlockBlob blockBlob)
        {
            using (var filestream = File.OpenRead(@"C:\Users\vishal\source\repos\Blob Storage - UploadingFile\Blob Storage - UploadingFile\Data\Demofile.txt"))
            {
                
                await blockBlob.UploadFromStreamAsync(filestream);
            }
        }
    }
}
