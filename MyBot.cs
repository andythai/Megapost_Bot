/* MyBot class
 Functions as main bot framework
 Methods are bot-specific, server-based interactions, 
 all interactions are run on server-side. 
*/

using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;

namespace Megapost {

    class MyBot {

        // Member variables
        DiscordClient discord;
        CommandService cmd;
        cmdlist commands = new cmdlist();
        List<Commands> cmds = new List<Commands>();
        String last;

        // Public constructor for Discord bot. Sets up bot
        public MyBot() {

            // Sets logs for discord client and initializes
            discord = new DiscordClient(x => {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            // Sets prefix character for bot chat recognition
            // Default: %
            discord.UsingCommands(x => {
                x.PrefixChar = '%';
                x.AllowMentionPrefix = true;
            });

            cmd = discord.GetService<CommandService>();
            
            newCmd();
            runCmd();
            undo();

            discord.ExecuteAndWait(async () => {
                await discord.Connect("MjY5MzA0NzI2ODkyMzE0NjI0.C1nmtA.cXSHU8KcGp1nZumpCQ_vt9C-PmE", TokenType.Bot);
                discord.SetGame("DECEPTIONS ATTACK!");
            });

            discord.MessageReceived += async (s, e) => {
                if (!e.Message.IsAuthor)
                    await e.Channel.SendMessage(e.Message+"");
            };

        }
        
        // Private helper method to append additional commands to bot
        private void newCmd() {
            cmd.CreateCommand("new")
                .Do(async (e) => {
                    await e.Channel.SendMessage("Enter a command and a link. \nDO NOT put a `%` in front of the command. \nDO NOT put embeds.\nUse '%undo' if you made a mistake.");
                    discord.MessageReceived += async (s, g) => {
                        String str=s.ToString();
                        String[] data = str.Split(null);
                        commands.add(data[0], data[1]);
                        last = data[0];
                        await (e.Channel.SendMessage(":ok_hand:"));
                    };
                });
        }


        // Private helper method to undo previous command setting and removes it from command list
        private void undo() {
            cmd.CreateCommand("undo")
                .Do(async (e) => {
                    commands.undo(last);
                    await e.Channel.SendMessage(":ok_hand:");
                });
        }
   
        // Private helper method to load commands from file
        private void runCmd() {
            foreach (Commands c in commands.reader()) {
                cmds.Add(c);
            }
            foreach (Commands c in cmds) {
                String name = c.getName();
                String URL = c.getURL();
                cmd.CreateCommand(name)
                    .Do(async (e) => {
                        await e.Channel.SendMessage(URL);
                    });
            }
        }


        // Private helper method logs bot activity
        private void Log(object sender, LogMessageEventArgs e) {
            Console.WriteLine(e.Message);
        }
    }
}