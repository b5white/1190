using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 {

    public class Config {
        Dictionary<string, string> values;
        string file;
        private bool modified;

        public Config() {
            internalConfig(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".config");
        }

        public Config(string path) {
            internalConfig(path);
        }

        ~Config() {
            if (modified) {
                string[] arr = values.Select(kvp => kvp.Key.ToString() + "=" + kvp.Value.ToString()).ToArray();
                File.WriteAllLines(file, arr);
            }
        }

        public void internalConfig(string path) {
            file = path;
            values = File.ReadLines(path)
                .Where(line => (!String.IsNullOrWhiteSpace(line) && !line.StartsWith("#")))
                .Select(line => line.Split(new char[] { '=' }, 2, 0))
                .ToDictionary(parts => parts[0].Trim(), parts => parts.Length > 1 ? parts[1].Trim() : null);
        }

        public string Value(string name, string value = null) {
            if (values != null && values.ContainsKey(name)) {
                return values[name];
            }
            return value;
        }

        public void SetValue(string name, string value) {
            modified = true;
            values[name] = value;
        }
    }
}


