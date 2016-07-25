using Discord;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord;
using System.Threading;
using Discord.Audio;

namespace PluginDiscordBot
{
    public class Program
    {
        static string key = "";
        public static string game = "";
        public static string botname = "";
        public static string prefix = "";
        public static string datafolder = "data";
        public static List<string> commands = new List<string>();
        public static List<string[]> plugins = new List<string[]>();
        public static IAudioClient _vClient;
        public interface IPluginInterface
        {
            string Name { get; }
            string Desc { get; }
            Func<ChannelEventArgs, bool> ChannelCreated { get; }
            Func<ChannelEventArgs, bool> ChannelDestroyed { get; }
            Func<ChannelUpdatedEventArgs, bool> ChannelUpdated { get; }
            Func<ServerEventArgs, bool> JoinedServer { get; }
            Func<ServerEventArgs, bool> LeftServer { get; }
            Func<MessageEventArgs, bool> MessageAcknowledged { get; }
            Func<MessageEventArgs, bool> MessageDeleted { get; }
            Func<MessageEventArgs, bool> MessageReceived { get; }
            Func<MessageEventArgs, bool> MessageSent { get; }
            Func<MessageUpdatedEventArgs, bool> MessageUpdated { get; }
            Func<ProfileUpdatedEventArgs, bool> ProfileUpdated { get; }
            Func<EventArgs, bool> Ready { get; }
            Func<RoleEventArgs, bool> RoleCreated { get; }
            Func<RoleUpdatedEventArgs, bool> RoleUpdated { get; }
            Func<RoleEventArgs, bool> RoleDeleted { get; }
            Func<ServerEventArgs, bool> ServerAvailable { get; }
            Func<ServerEventArgs, bool> ServerUnavailable { get; }
            Func<ServerUpdatedEventArgs, bool> ServerUpdated { get; }
            Func<UserEventArgs, bool> UserBanned { get; }
            Func<ChannelUserEventArgs, bool> UserTyping { get; }
            Func<UserEventArgs, bool> UserJoined { get; }
            Func<UserEventArgs, bool> UserLeft { get; }
            Func<UserEventArgs, bool> UserUnbanned { get; }
            Func<UserUpdatedEventArgs, bool> UserUpdated { get; }
            Func<bool> Setup { get; }
            DiscordClient _client { set; }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Reading config");
            readconfig();
            Console.WriteLine("Checking folders");
            if (!Directory.Exists("Plugins"))
            {
                Directory.CreateDirectory("Plugins");
            }
            if (!Directory.Exists(datafolder))
            {
                Directory.CreateDirectory(datafolder);
            }
            Console.WriteLine("Loading plugins");
            IPluginInterface[] ipi = PluginLoader.GetPlugins("plugins");
            foreach (var plugin in ipi)
            {
                Console.WriteLine(plugin.Name + " loaded!\nDescription: " + plugin.Desc + "\n");
                plugins.Add(new string[2] { plugin.Name, plugin.Desc });
            }
            DiscordClient _client = new DiscordClient();

            _client.UsingAudio(x =>
            {
                x.Mode = AudioMode.Outgoing;
            });
            Console.WriteLine("Setting audio client");

            Console.WriteLine("Setting events");
            _client.ChannelCreated += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.ChannelCreated(e);
                }
            };

            _client.ChannelDestroyed += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.ChannelDestroyed(e);
                }
            };

            _client.ChannelUpdated += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.ChannelUpdated(e);
                }
            };

            _client.JoinedServer += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.JoinedServer(e);
                }
            };

            _client.LeftServer += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.LeftServer(e);
                }
            };

            _client.MessageAcknowledged += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.MessageAcknowledged(e);
                }
            };

            _client.MessageDeleted += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.MessageDeleted(e);
                }
            };

            _client.MessageReceived += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.MessageReceived(e);
                }
            };

            _client.MessageSent += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.MessageSent(e);
                }
            };

            _client.MessageUpdated += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.MessageUpdated(e);
                }
            };

            _client.ProfileUpdated += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.ProfileUpdated(e);
                }
            };

            _client.Ready += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.Ready(e);
                }
            };

            _client.RoleCreated += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.RoleCreated(e);
                }
            };

            _client.RoleDeleted += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.RoleDeleted(e);
                }
            };

            _client.RoleUpdated += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.RoleUpdated(e);
                }
            };

            _client.ServerAvailable += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.ServerAvailable(e);
                }
            };

            _client.ServerUnavailable += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.ServerUnavailable(e);
                }
            };

            _client.ServerUpdated += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.ServerUpdated(e);
                }
            };

            _client.UserBanned += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.UserBanned(e);
                }
            };

            _client.UserIsTyping += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.UserTyping(e);
                }
            };

            _client.UserJoined += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.UserJoined(e);
                }
            };

            _client.UserLeft += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.UserLeft(e);
                }
            };

            _client.UserUnbanned += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.UserUnbanned(e);
                }
            };

            _client.UserUpdated += (s, e) =>
            {
                foreach (var plugin in ipi)
                {
                    plugin.UserUpdated(e);
                }
            };

            _client.ExecuteAndWait(async () => {
                Console.WriteLine("Connecting to Discord using your key");
                await _client.Connect(key);
                Console.WriteLine("Setting game to configured game");
                _client.SetGame(game, GameType.Default, "");
                Console.WriteLine("Setting name to configured name");
                await _client.CurrentUser.Edit(username: botname);
                foreach (var plugin in ipi)
                {
                    plugin._client = _client;
                    plugin.Setup();
                }
            });
        }

        static void readconfig()
        {
            if (!File.Exists("config.conf"))
            {
                File.Create("config.conf").Close();
                File.WriteAllText("config.conf", @"botname=PluginDiscordBot
botgame=PluginDiscordBot! <3
bottoken=your token here.
prefix=!
datafolder=data");
                Console.WriteLine("Please set up config.conf.");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                Environment.Exit(0);
            }else
            {
                string[] config = File.ReadAllLines("config.conf");
                foreach (string line in config)
                {
                    if (line.StartsWith("botname="))
                    {
                        botname = line.Substring(8);
                    }
                    if (line.StartsWith("botgame="))
                    {
                        game = line.Substring(8);
                    }
                    if (line.StartsWith("bottoken="))
                    {
                        key = line.Substring(9);
                    }
                    if (line.StartsWith("prefix="))
                    {
                        prefix = line.Substring(7);
                    }
                    if (line.StartsWith("datafolder="))
                    {
                        datafolder = line.Substring(11);
                    }
                }
            }
        }
    }
}
