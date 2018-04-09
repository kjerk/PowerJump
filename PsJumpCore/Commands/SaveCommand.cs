using System.Management.Automation;
using Core.Data;

namespace Core.Commands
{
	[Cmdlet(VerbsData.Save, "Jumps")]
	[Alias("savejumps")]
	public class SaveCommand : PSCmdlet
	{
		[Parameter(Mandatory = false, HelpMessage = "Overwrites Jumps.json on disk regardless if disk version is newer than loaded.")]
		public bool Force { get; set; } = false;

		private readonly JumpLookup _jumps = JumpLookup.Instance;

		protected override void ProcessRecord() => _jumps.Save(Force);
	}
}
