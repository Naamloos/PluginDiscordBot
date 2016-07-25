using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static PluginDiscordBot.Program;

namespace PluginDiscordBot
{
    class PluginLoader
    {
        public static IPluginInterface[] GetPlugins(string directory)
        {
            if (String.IsNullOrEmpty(directory)) { return null; } //sanity check

            DirectoryInfo info = new DirectoryInfo(directory);
            if (!info.Exists) { return null; } //make sure directory exists

            List<IPluginInterface> plugins = new List<IPluginInterface>();
            foreach (FileInfo file in info.GetFiles("*.dll")) //loop through all dll files in directory
            {
                //using Reflection, load Assembly into memory from disk
                Assembly currentAssembly = Assembly.LoadFile(file.FullName);

                //Type discovery to find the type we're looking for which is IPluginInterface
                foreach (Type type in currentAssembly.GetTypes())
                {
                    //Create instance of class that implements IPluginInterface and cast it to type
                    //IPluginInterface and add it to our list
                    IPluginInterface plugin = (IPluginInterface)Activator.CreateInstance(type);
                    plugins.Add(plugin);
                }
            }

            return plugins.ToArray();
        }
    }
}
