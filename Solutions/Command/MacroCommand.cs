using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Command
{
    public class MacroCommand : ICommand
    {
        private Document _document;
        private readonly IList<ICommand> _commands;


        public MacroCommand(Document document, IList<ICommand> commands)
        {
            _document = document;
            _commands = commands;
        }   

        public void Execute()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
        }

        public void Undo()
        {
            foreach (var command in _commands.Reverse())
            {
                command.Undo();
            }
        }
    }
}