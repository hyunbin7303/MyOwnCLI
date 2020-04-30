using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace HP_CLI_Infrastructure.Azure.AzureStorage
{
    // Azure storage includes data services such as:
    // Azure Blobs - A massively scalable object store for text.
    // Azure Files - Managed file shares for cloud or on-premises deployments.
    // Azure Queues - A messaging store for reliable messaging between application components.
    // Azure Tables - A NoSQL store for schemaless storage of structured data.
    public class BlobStorage : AzureDefault
    {




        public BlobStorage()
        {
            //    service = _account != null ? new TaskDataService(clientId, _account) : new TaskDataService(clientId);
        }
        //Blob storage offers 3 types of resource.
        //A storage account provides a unique namespace in Azure for your data.
        public void SetupStorageAccount()
        {
            Setup("CHECK");
            StorageCredentials storageCredentials = new StorageCredentials("", "");
            //cloudStorageAccount = new CloudStorageAccount(storageCredentials, useHttps: true);
        }
        public Tuple<string, string> fileLocation(string filePath = null)
        {
            string localPath = "C:\\KevinAppTesting";
            string fileName = "quickstart" + Guid.NewGuid().ToString() + ".txt";
            string localFilePath = Path.Combine(localPath, fileName);
            return Tuple.Create(fileName, localFilePath);
        }

        public string ConnectionString { get; set; } = AzureStorageConfig.ConnectionString();


        public void UploadFileToBlob(string containerName, string localPath, string fileName)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(ConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            string localFilePath = Path.Combine(localPath, fileName);
            BlobClient blobClient = containerClient.GetBlobClient(fileName);
            using FileStream uploadFileStream = File.OpenRead(localFilePath);
           blobClient.Upload(uploadFileStream, true);
            uploadFileStream.Close();
            //return await Task.FromResult(true);
        }

        // specify a number of options to manage how results are returned from Azure storage.
        public async Task<bool> ListBlobs(string containerName)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(ConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
            {
                Console.WriteLine("\t" + blobItem.Name);
            }
            return await Task.FromResult(true);
        }

        public void ListBlobsTest(string containerName)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(ConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            foreach (BlobItem blobItem in containerClient.GetBlobs())
            {
                Console.WriteLine("\t" + blobItem.Name);
            }
        }

        public void updateUsingMemoryStream()
        {
            const string content = "HAHASJFHFLKSHAJFSLAFHKSALJ";
            byte[] byteArray = Encoding.UTF8.GetBytes(content);
            MemoryStream stream = new MemoryStream(byteArray);
            BlobServiceClient blobServiceClient = new BlobServiceClient(ConnectionString);
            BlockBlobClient blobClient =
                blobServiceClient.GetBlobContainerClient("democontainer").GetBlockBlobClient("");
            blobClient.Upload(stream);
            Console.WriteLine("DONE");
        }


        protected void EnmeratingBlobs()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = "<connection_string>";
            string containerName = "sample-container";
            string filePath = "hello.jpg";
            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
            container.Create();
            // Upload a few blobs so we have something to list
            container.UploadBlob("first", File.OpenRead(filePath));
            container.UploadBlob("second", File.OpenRead(filePath));
            container.UploadBlob("third", File.OpenRead(filePath));
            // Print out all the blob names
            foreach (BlobItem blob in container.GetBlobs())
            {
                Console.WriteLine(blob.Name);
            }
        }
        public void DownloadBlobs(string containerName)
        {

        }


        //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/stackalloc
        //public void testing()
        //{
        //    int length = 3;
        //    Span<int> numbers = stackalloc int[length];
        //    for (var i = 0; i < length; i++) { 
        //        numbers[i] = i;
        //    }
        //}


    }


}
