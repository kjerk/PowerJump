using System.Management.Automation;
using Core.Data;

namespace Core.Commands
{
	[Cmdlet(VerbsData.Import, "Jumps")]
	[Alias("loadjumps")]
	public class ImportCommand : PSCmdlet
	{
		private readonly JumpLookup _jumps = JumpLookup.Instance;

		protected override void ProcessRecord() => _jumps.Load();
	}
}
