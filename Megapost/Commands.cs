using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Megapost {
    class Commands {
        String name;
        String URL;

        public Commands(String name, String URL) {
            this.name = name;
            this.URL = URL;
        }

        public void setName(String name) {
            this.name = name;
        }

        public String getName() {
            return name;
        }

        public void setURL(String URL) {
            this.URL = URL;
        }

        public String getURL() {
            return URL;
        }
    }
}
