using System.Management.Automation;
using PowerJump.Data;

namespace PowerJump.Commands
{
	[Cmdlet(VerbsData.Import, "Jumps")]
	[Alias("loadjumps")]
	public class ImportCommand : PSCmdlet
	{
		private readonly JumpLookup _jumps = JumpLookup.Instance;

		protected override void ProcessRecord() => _jumps.Load();
	}
}
