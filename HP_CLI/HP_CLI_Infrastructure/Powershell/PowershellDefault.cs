using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
namespace HP_CLI_Infrastructure.Powershell
{
    public abstract class PowershellDefault
    {
        public string Setup()
        {
            return string.Empty;
        }
        public List<string> FindAll_scriptName()
        {
            return new List<string>();
        }
        public string FolderLocation(string scriptName)
        {
            return @"C:\PowershellScript\" + scriptName;
        }
        void NoError()
        {
            var ps1File = @"C:\my script folder\script.ps1";
            var startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy unrestricted -file \"{ps1File}\"",
                UseShellExecute = false
            };
            Process.Start(startInfo);
        }
            public bool RunPowershellScript(string fileLoc)
        {
            var file = FolderLocation(fileLoc);
            var startpsInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = "",
                UseShellExecute = false
            };
            Process.Start(startpsInfo);
            return true;
        }
    }
}
