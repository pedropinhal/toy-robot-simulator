using System;
using System.Collections.Generic;
using System.Linq;

namespace ToyRobotSimulator.Business
{
    public class Command
    {
        public CommandVerb Verb { get; private set; }
        public List<string> Arguments { get; private set; }

        protected Command(CommandVerb verb, List<string> arguments)
        {
            Verb = verb;
            Arguments = arguments;
        }

        public static Command Parse(string command)
        {
            var parts = command.Split(' ');
            CommandVerb verb;
            if (Enum.TryParse(parts[0], out verb))
            {
                var arguments = (parts.Length > 1) ?
                    parts[1].Split(',').ToList() :
                    null;
                return new Command(verb, arguments);
            }

            return null;
        }
    }

}


