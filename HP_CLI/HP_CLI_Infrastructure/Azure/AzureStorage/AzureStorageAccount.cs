using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Azure.Storage.Blobs;
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



    public class BlobStorage
    {
        // Object storage solution for the cloud.
        // Optimized for storing massive amounts of unstructured data.
        //Text or binary data.
        // seving images or documents directly to a broswer.
        // Storing files for distributed access. 
        // Storing data for analysis by an on-premises or Azure-hosted service.

        //Blob storage offers 3 types of resource.
        //A storage account provides a unique namespace in Azure for your data.
        private static CloudStorageAccount cloudStorageAccount;
        private static CloudBlobClient blobClient;
        private static string connectionString =
            "DefaultEndpointsProtocol=https;AccountName=kevinazurestorage;AccountKey=hRSBs4SLf/lCs78U0UZnK0cbGnohaeGug/U4rvk96m4xTHvItY0MdBDiU/Oswy8NQvakntk8Si4yg2ClumUNCg==;EndpointSuffix=core.windows.net";
        public void SetupStorageAccount()
        {
            StorageCredentials storageCredentials = new StorageCredentials("", "");
            cloudStorageAccount = new CloudStorageAccount(storageCredentials, useHttps: true);
        }
        
        public void BlobClient_Testing()
        {
            blobClient = cloudStorageAccount.CreateCloudBlobClient();
            // A container in the storage account used via BlobContainerClient
            // A blob in a container used via BlobClient
            string connStr = "";
            string blobName = "";
            string filePath = "";
            string connectionString = Environment.ExpandEnvironmentVariables("AZURE_STORAGE_CONNECTION_STRING");
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            string containerName = "quickstartblobs" + Guid.NewGuid().ToString();
            BlobContainerClient containerClient = blobServiceClient.CreateBlobContainer(containerName);



            string localPath = "./data/";
            string fileName = "quickstart" + Guid.NewGuid().ToString() + ".txt";
            string localFilePath = Path.Combine(localPath, fileName);

            File.WriteAllText(localFilePath, "Hello, World");
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);

            // Open the file and upload its data
            using FileStream uploadFileStream = File.OpenRead(localFilePath);
            blobClient.UploadAsync(uploadFileStream, true);
            uploadFileStream.Close();

        }
        
    }
    
    
}
