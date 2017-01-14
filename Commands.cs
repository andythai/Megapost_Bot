/** Command class **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Megapost {
    class Commands {
        // Member variables
        String name;
        String URL;

        // Public constructor
        public Commands(String name, String URL) {
            this.name = name;
            this.URL = URL;
        }

        // Setter method for command name
        public void setName(String name) {
            this.name = name;
        }

        // Getter method for command name
        public String getName() {
            return name;
        }

        // Setter method for command URL
        public void setURL(String URL) {
            this.URL = URL;
        }

        // Getter method for command URL
        public String getURL() {
            return URL;
        }
    }
}
