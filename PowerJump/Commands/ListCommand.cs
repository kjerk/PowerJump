using System;
using System.Linq;
using System.Management.Automation;
using PowerJump.Data;

namespace PowerJump.Commands
{
	[Cmdlet(VerbsCommon.Get, "Jumps")]
	[Alias("jumps")]
	public class ListCommand : PSCmdlet
	{
		private JumpLookup jumps = JumpLookup.Instance;

		protected override void ProcessRecord() {
			var allJumps = jumps.ListAll();
			allJumps.Sort((t1,t2) => String.Compare(t1.Item1, t2.Item1, StringComparison.Ordinal));
			int longest = allJumps.Max(t1 => t1.Item1.Length);
			foreach (var aliasPair in jumps.ListAll()) {
				Console.WriteLine($"{aliasPair.Item1.PadRight(longest)}: {aliasPair.Item2}");
			}
		}
	}
}
