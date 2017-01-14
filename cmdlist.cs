/** cmdlist class **/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megapost {

    class cmdlist {

        // Grabs memes.txt from the current working directory
        // memes.txt functions as the settings file for bot commands
        String dir = Path.Combine(Directory.GetCurrentDirectory(), "memes.txt");
        StreamReader file;

        // cmdlist class constructor
        public cmdlist() {
            file = new StreamReader(dir);
        }

        // reader() reads through memes.txt and pulls data into bot command repository
        public List<Commands> reader() {
            String line;
            List<Commands> cmds = new List<Commands>();
            while ((line = file.ReadLine()) != null) {
                string[] cmd = line.Split(null);
                cmds.Add(new Megapost.Commands(cmd[0], cmd[1]));
            }
            return cmds;
        }

        // add(name, URL) appends an additional command and corresponding URL to memes.txt
        public void add(String name, String URL) {
            StreamWriter w = File.AppendText(dir);
            w.WriteLine(name + " " + URL);
        }

        // undo(name) removes command 'name' from memes.txt and updates it
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
