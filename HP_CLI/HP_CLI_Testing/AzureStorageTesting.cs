using HP_CLI_Infrastructure.Azure.AzureStorage;
using NUnit.Framework;


namespace HP_CLI_Testing
{
    public class AzureStorageTesting
    {
        [Test]
        public void testing()
        {
            BlobStorage test1 = new BlobStorage();
            test1.BlobClient_Testing();
        }
    }
}
