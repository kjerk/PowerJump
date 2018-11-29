using System;
using System.Management.Automation;
using PowerJump.Data;

namespace PowerJump.Commands
{
	[Cmdlet(VerbsCommon.Remove, "Jump")]
	[Alias("unmark")]
	public class RemoveCommand : PSCmdlet
	{
		private JumpLookup jumps = JumpLookup.Instance;

		[Parameter(Mandatory = true, Position = 1)]
		public string Alias { get; set; }

		protected override void ProcessRecord() {
			if (Alias.Length > 0 && jumps.Has(Alias)) {
				jumps.Remove(Alias);
				Console.WriteLine($"Alias {Alias} removed.");
			} else {
				Console.WriteLine($"Alias {Alias} not found.");
			}
		}
	}
}
