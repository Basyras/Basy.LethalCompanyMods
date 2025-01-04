using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Basy.LethalCompany.Utilities.Commands
{

    public static class CommandsHelper
    {
        private readonly static Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

        public static void AddCommands<TAssemblyMarker>()
        {
            AddCommands(typeof(TAssemblyMarker).Assembly);
        }
        public static void AddCommands(Assembly assembly)
        {
            var commandsToAdd = assembly
                .GetTypes()
                .Where(x => typeof(ICommand).IsAssignableFrom(x))
                .Where(x => x.IsAbstract is false)
                .Where(x => x.IsInterface is false)
                .Select(x => (ICommand)Activator.CreateInstance(x));

            foreach (var command in commandsToAdd)
            {
                BLUtils.Logger.LogInfo($"Adding command '{command.GetType().Name}' from '{assembly.GetName().Name}'");
                commands.Add(command.Command, command);
            }
        }

        public static bool TryExecute(string message)
        {
            var tokens = message.Split(' ');
            if (tokens.Length > 1)
            {
                commands.TryGetValue(tokens[0], out var command);
                if (command != null)
                {
                    var args = tokens.Length == 1 ? Array.Empty<string>() : tokens.Skip(1).ToArray();
                    command.ExecuteAsync(args).GetAwaiter().GetResult();
                    return true;
                }
            }

            return false;
        }
    }
}
