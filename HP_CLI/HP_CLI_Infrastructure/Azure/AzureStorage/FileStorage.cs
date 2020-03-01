using System;
using System.Collections.Generic;
using System.Text;

namespace HP_CLI_Infrastructure.Azure.AzureStorage
{
    public class FileStorage : AzureDefault
    {
        public override void Setup(string str)
        {
            base.Setup(str);
            Console.WriteLine("HELLO Setup overriding.");
        }

        public FileStorage()
        {
            Setup("CHECK");
        }
    }
}
