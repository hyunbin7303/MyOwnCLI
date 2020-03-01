using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
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
        // Object storage solution for the cloud.
        // Optimized for storing massive amounts of unstructured data.
        //Text or binary data.
        // seving images or documents directly to a broswer.
        // Storing files for distributed access. 
        // Storing data for analysis by an on-premises or Azure-hosted service.

        //Blob storage offers 3 types of resource.
        //A storage account provides a unique namespace in Azure for your data.
        //public void SetupStorageAccount()
        //{
        //    Setup("CHECK");
        //    StorageCredentials storageCredentials = new StorageCredentials("", "");
        //    cloudStorageAccount = new CloudStorageAccount(storageCredentials, useHttps: true);
        //}

        private static CloudBlobClient blobClient = null;


        public Tuple<string, string> fileLocation()
        {
            string localPath = "C:\\KevinAppTesting";
            string fileName = "quickstart" + Guid.NewGuid().ToString() + ".txt";
            string localFilePath = Path.Combine(localPath, fileName);
            return Tuple.Create(fileName,localFilePath);
        }

        public BlobServiceClient GetBlobServiceClient()
        {
            string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            return blobServiceClient;
        }
        public void BlobClient_Testing()
        {
            string containerName = "quickstartblobs" + Guid.NewGuid().ToString();
            BlobContainerClient containerClient = GetBlobServiceClient().CreateBlobContainer(containerName);
            File.WriteAllText(fileLocation().Item2, "Hello, World");
            BlobClient blobClientTesting = containerClient.GetBlobClient(fileLocation().Item1);
            Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClientTesting.Uri);
            // Open the file and upload its data
            using FileStream uploadFileStream = File.OpenRead(fileLocation().Item2);
            blobClientTesting.Upload(uploadFileStream, true);
            uploadFileStream.Close();
        }

        public void EnmeratingBlobs()
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
        // Testing for Async and sync


        // Authenticating with Azure.Identity.
        public void Authentication()
        {

        }


        
    }
    
    
}
