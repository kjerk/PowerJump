using System.Diagnostics;
using System.Management.Automation;
using PowerJump.Data;

namespace PowerJump.Commands
{
	[Cmdlet(VerbsData.Edit, "Jumps")]
	[Alias("editjumps")]
	public class EditCommand : PSCmdlet
	{
		private readonly JumpLookup _jumps = JumpLookup.Instance;

		protected override void ProcessRecord() {
			Process.Start(_jumps.JsonFilePath)?.WaitForExit();
			InvokeCommand.InvokeScript("Import-Jumps");
			InvokeCommand.InvokeScript("Get-Jumps");
		}
	}
}
