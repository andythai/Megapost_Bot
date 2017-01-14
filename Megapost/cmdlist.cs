using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megapost {
    class cmdlist {
        String dir = Path.Combine(Directory.GetCurrentDirectory(), "memes.txt");
        StreamReader file;
        public cmdlist() {
            file = new StreamReader(dir);
        }

        public List<Commands> reader() {
            String line;
            List<Commands> cmds = new List<Commands>();
            while ((line = file.ReadLine()) != null) {
                string[] cmd = line.Split(null);
                cmds.Add(new Megapost.Commands(cmd[0], cmd[1]));
            }
            return cmds;
        }

        public void add(String name, String URL) {
            StreamWriter w = File.AppendText(dir);
            w.WriteLine(name + " " + URL);
        }

        public void undo(String name) {
            String[] read = File.ReadAllLines(dir);
            List<String> lines = read.OfType<String>().ToList();
            foreach(String s in lines) {
                String[] line = s.Split(null);
                if (line[0].Equals(name)) lines.Remove(s);
                break;
            }
        }
    }
}
