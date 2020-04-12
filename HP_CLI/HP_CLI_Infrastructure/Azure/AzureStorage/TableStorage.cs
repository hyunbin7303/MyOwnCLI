using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;


/*
Azure Table storage stores large amounts of structured data. The service is a NoSQL datastore 
which accepts authenticated calls from inside and outside the Azure cloud.
Azure tables are ideal for storing structured, non-relational data. Common uses of Table storage include:
    Storing TBs of structured data capable of serving web scale applications
    Storing datasets that don't require complex joins, foreign keys, or stored procedures and can 
    be denormalized for fast access
    Quickly querying data using a clustered index
    Accessing data using the OData protocol and LINQ queries with WCF Data Service .NET Libraries
 */


namespace HP_CLI_Infrastructure.Azure.AzureStorage
{
    public class TableStorage : AzureDefault
    {
        public CloudTable Createtable(string tableName)
        {
            //CloudStorageAccount storageAccount = 
            CloudTable ct = new CloudTable(new Uri("hhahahahahh"));
            return ct;
        }
    }
}
