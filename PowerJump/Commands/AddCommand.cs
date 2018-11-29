using System;
using System.Management.Automation;
using Core.Data;

namespace Core.Commands
{
	[Cmdlet(VerbsCommon.Add, "Jump")]
	[Alias("mark")]
	public class AddCommand : PSCmdlet
	{
		private readonly JumpLookup _jumps = JumpLookup.Instance;

		[Parameter(Mandatory = true, Position = 1)]
		public string Alias { get; set; }

		[Parameter(Mandatory = false, Position = 2)]
		public string Path { get; set; }

		[Parameter(Mandatory = false, HelpMessage = "Overwrite if Alias already exists.")]
		[Alias("-F")]
		public SwitchParameter Force { get; set; }

		protected override void ProcessRecord() {
			var targetDir = Path ?? CurrentProviderLocation("FileSystem").ProviderPath;

			if (_jumps.Set(Alias, targetDir, Force.IsPresent)) {
				Console.WriteLine($"[{Alias}] assigned to [{targetDir}]");
			} else {
				Console.WriteLine($"[{Alias}] already assigned to [{_jumps.Get(Alias)}], pass -Force to overwrite.");
			}
		}
	}
}
