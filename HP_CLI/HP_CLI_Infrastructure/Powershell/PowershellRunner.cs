using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace HP_CLI_Infrastructure.Powershell
{



    public class PowershellRunner : PowershellDefault
    {
        public static void PS_AzureConnectionCheck()
        {

        }

        public static void PS_AzureMyInfo()
        {

        }

        public static void PS_UpdateDependencies()
        {
            // Run UpdateDependencies script in here.

        }

        public void OpenWithArguments()
        {
            Process.Start("IExplorer.exe", "www.google.com");
        }

        public void OpenWithStartInfo()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("IExplorer.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Minimized;
            Process.Start(startInfo);
            startInfo.Arguments = "www.google.com";
            Process.Start(startInfo);
        }
    }
}
