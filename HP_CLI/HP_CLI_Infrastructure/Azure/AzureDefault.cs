using System;
using System.Collections.Generic;
using System.Text;
using HP_CLI_Infrastructure.Azure.AzureStorage;

namespace HP_CLI_Infrastructure.Azure
{
    /*
If you anticipate creating multiple versions of your component, create an abstract class. 
Abstract classes provide a simple and easy way to version your components. 
By updating the base class, all inheriting classes are automatically updated with the change. 
Interfaces, on the other hand, cannot be changed once created.
If a new version of an interface is required, you must create a whole new interface.
If the functionality you are creating will be useful across a wide range of disparate objects, use an interface. 
 1. Versioning.
 An abstract class can contain an interface plus implementations. This simplifies versioning.
 2. Design Flexibility.
Base class library using Abstract class. 
Use an interaface to design a polymorphic hierarchy for value types.
* */


    public enum AzureStorageType
    { 
        AzBlobStorage,
        AzFileStorage,
        AzTableStorage
    }
    public abstract class AzureDefault
    {
        public virtual void Setup(string str)
        {
        }
        public virtual bool SetupIsSuccess()
        {
            return true;
        }
        public virtual string setupCloudStorageAccount(AzureStorageType storageType)
        {
            string ConnectionString = string.Empty;
            switch (storageType)
            {
                case AzureStorageType.AzBlobStorage:
                    ConnectionString = "";
                    break;

                case AzureStorageType.AzFileStorage:
                    ConnectionString = "";
                    break;

                case AzureStorageType.AzTableStorage:
                    ConnectionString = "";
                    break;

                default:
                    break;
            }
            return ConnectionString;
        }
    }
}
