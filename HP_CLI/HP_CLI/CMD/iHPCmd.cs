using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace HP_CLI
{

        [Command(Name = "Kevin", ThrowOnUnexpectedArgument = false, OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
        [VersionOptionFromMember("--version", MemberName = nameof(GetVersion))]
        [Subcommand(
            typeof(LoginCmd),
            typeof(ListTicketCmd))]
        public class iHPCmd : iHPCmdBase
        {
        public iHPCmd(ILogger<iHPCmd> logger, IConsole console)
        {
            _logger = logger;
            _console = console;
        }

        protected override Task<int> OnExecute(CommandLineApplication app)
        {
            // this shows help even if the --help option isn't specified
            app.ShowHelp();
            return Task.FromResult(0);
        }

        private static string GetVersion()
            => typeof(iHPCmd).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion + " HEHEHEH";
    }

}
