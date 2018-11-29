using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using fastJSON;

namespace Core.Data
{
	internal class JumpLookup
	{
	    public static JumpLookup Instance { get; private set; } = new JumpLookup();

        internal readonly string JsonFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Jumps.json");

		private long _lastUpdated;
		private Dictionary<string, string> _jumps = new Dictionary<string, string>();

		public JumpLookup() {
			if(File.Exists(JsonFilePath)) {
				Load();
			} else {
				_lastUpdated = DateTime.Now.ToFileTimeUtc();
			}
		}

		public void Save(bool force = false) {
			if (NeedsUpdate() && !force) { // This means we have a collision, the file has been updated outside the scope of this class.
				Console.Error.WriteLine("Error: Jumps.json file has been updated outside the scope of this console.");
				Console.Error.WriteLine("Error: Please call Save-Jumps -Force to overwrite, or Load-Jumps to reload from disk.");
				return;
			}

			if (File.Exists(JsonFilePath)) {
				File.Copy(JsonFilePath, JsonFilePath.Replace(".json", ".prev.json"), true);
			}
			File.WriteAllText(JsonFilePath, JSON.ToNiceJSON(_jumps));
			UpdateLastUpdatedTime();
		}

		private bool NeedsUpdate() => File.GetLastWriteTime(JsonFilePath).ToFileTimeUtc() > _lastUpdated;

		public void UpdateLastUpdatedTime() {
			_lastUpdated = File.GetLastWriteTime(JsonFilePath).ToFileTimeUtc();
		}

		public void Load() {
			UpdateLastUpdatedTime();
			var tempDict = (Dictionary<string, object>)JSON.Parse(File.ReadAllText(JsonFilePath));
			foreach (var kvp in tempDict) {
				_jumps[kvp.Key] = kvp.Value.ToString();
			}
			Console.WriteLine($"[{_jumps.Count}] Jump(s) loaded");
		}

		public bool Has(string alias) => _jumps.ContainsKey(alias);

		public string Get(string alias) => _jumps[alias];

		public bool Set(string alias, string folderPath, bool overwrite = false) {
			if (_jumps.ContainsKey(alias)) {
				if (!overwrite) {
					return false;
				}
				_jumps.Remove(alias);
			}
			_jumps.Add(alias, folderPath);
			Save();
			return true;
		}

		public void Remove(string alias) {
			_jumps.Remove(alias);
			Save();
		}

		public List<Tuple<string, string>> ListAll() =>
			(from kvp in _jumps select Tuple.Create(kvp.Key, kvp.Value)).ToList();

	}
}
