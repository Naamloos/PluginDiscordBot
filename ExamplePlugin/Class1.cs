using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

/*
//--------------------PROGRAMMING INFO--------------------\\

    Replace Null with a function
    doesnt matter if you return true or false
    Your discordclient is called dclient here
    Programming is exactly like in Discord.Net

    Available variables:
    prefix: preferred command prefix
    datafolder: preferred folder to save files(temporarily)
    botname: bot name
    botgame: bot game
    commands: commands list, add your commands to this list
    plugins: plugins list, plugins get added automatically.
    { name, desc }
    _vClient: Voice client to use for voice channel

\\--------------------PROGRAMMING INFO--------------------//
*/
namespace ExamplePlugin
{
    using static PluginDiscordBot.Program;
    public class Class1 : IPluginInterface
    {
        public DiscordClient dclient;
        public string Name
        {
            get { return "Your Plugin Name"; }
        }

        public string Desc
        {
            get { return "Your plugin description"; }
        }

        public Func<ChannelEventArgs, bool> ChannelCreated
        {
            get { return null; }
        }

        public Func<ChannelEventArgs, bool> ChannelDestroyed
        {
            get { return null; }
        }

        public Func<ChannelUpdatedEventArgs, bool> ChannelUpdated
        {
            get { return null; }
        }

        public Func<ServerEventArgs, bool> JoinedServer
        {
            get { return null; }
        }

        public Func<ServerEventArgs, bool> LeftServer
        {
            get { return null; }
        }

        public Func<MessageEventArgs, bool> MessageAcknowledged
        {
            get { return null; }
        }

        public Func<MessageEventArgs, bool> MessageDeleted
        {
            get { return null; }
        }

        public Func<MessageEventArgs, bool> MessageReceived
        {
            get { return null; }
        }

        public Func<MessageEventArgs, bool> MessageSent
        {
            get { return null; }
        }

        public Func<MessageUpdatedEventArgs, bool> MessageUpdated
        {
            get { return null; }
        }

        public Func<ProfileUpdatedEventArgs, bool> ProfileUpdated
        {
            get { return null; }
        }

        public Func<EventArgs, bool> Ready
        {
            get { return null; }
        }

        public Func<RoleEventArgs, bool> RoleCreated
        {
            get { return null; }
        }

        public Func<RoleEventArgs, bool> RoleDeleted
        {
            get { return null; }
        }

        public Func<RoleUpdatedEventArgs, bool> RoleUpdated
        {
            get { return null; }
        }

        public Func<ServerEventArgs, bool> ServerAvailable
        {
            get { return null; }
        }

        public Func<ServerEventArgs, bool> ServerUnavailable
        {
            get { return null; }
        }

        public Func<ServerUpdatedEventArgs, bool> ServerUpdated
        {
            get { return null; }
        }

        public Func<UserEventArgs, bool> UserJoined
        {
            get { return null; }
        }

        public Func<UserEventArgs, bool> UserLeft
        {
            get { return null; }
        }

        public Func<UserEventArgs, bool> UserBanned
        {
            get { return null; }
        }

        public Func<ChannelUserEventArgs, bool> UserTyping
        {
            get { return null; }
        }

        public Func<UserEventArgs, bool> UserUnbanned
        {
            get { return null; }
        }

        public Func<UserUpdatedEventArgs, bool> UserUpdated
        {
            get { return null; }
        }

        public DiscordClient _client
        {
            set
            {
                dclient = value;
            }
        }

        public Func<bool> Setup
        {
            get { return SetupFunc; }
        }

        public bool SetupFunc()
        {
            Console.WriteLine("Random Console Message Thingy");
            return true;
        }
    }
}
