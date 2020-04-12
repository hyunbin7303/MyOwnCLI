using System;
using System.IO;
using Azure.Storage.Blobs.Models;
using HP_CLI_Infrastructure.Azure;
using HP_CLI_Infrastructure.Azure.AzureStorage;
using NUnit.Framework;


namespace HP_CLI_Testing
{
    public class AzureStorageTesting
    {

        [Test]
        public void EnumeratingUsageTest()
        {
            BlobStorage test2 = new BlobStorage();
            //test2.UploadSomething("C:\\kevin.jpg", "What is ref name?;;;");
        }
        [Test]
        public void UploadedFileTest()
        {
            BlobStorage test = new BlobStorage();
            test.UploadFileToBlob("democontainer", "C:\\KevinAppTesting\\Image", "Pichachu.png");
        }

        [Test]
        public void ListBlobsInContainerTest()
        {
            BlobStorage test = new BlobStorage();
            test.ListBlobs("democontainer");
        }

    }
}
