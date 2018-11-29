using System;
using System.Management.Automation;
using PowerJump.Data;

namespace PowerJump.Commands
{
	[Cmdlet(VerbsCommon.Find, "Jump")]
	[Alias("jump", "j")]
	public class JumpCommand : PSCmdlet
	{
		private JumpLookup jumps = JumpLookup.Instance;

		[Parameter(Mandatory = true, Position = 1)]
		public string Alias { get; set; }

		protected override void ProcessRecord() {
			if (jumps.Has(Alias)) {
				InvokeCommand.InvokeScript($"cd \"{jumps.Get(Alias)}\"");
			} else {
				Console.WriteLine($"Alias [{Alias}] not found.");
			}
		}

	}
}
