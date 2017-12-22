using System;
using System.Collections.Generic;
using System.Linq;

namespace CauldronMinimal.History
{
    public static class CommandManager
    {
        private static readonly Stack<ICommand> UndoCommands = new Stack<ICommand>();
        private static readonly Stack<ICommand> RedoCommands = new Stack<ICommand>();
        public static bool HasUndoItems => UndoCommands.Any();

        public static bool HasRedoItems => RedoCommands.Any();

        public static void PerformCommand(ICommand command)
        {
            RedoCommands.Clear();
            UndoCommands.Push(command);
            command.Perform();
        }

        public static void Undo()
        {
            try
            {
                var command = UndoCommands.Pop();
                command.Undo();
                RedoCommands.Push(command);
            }
            catch (InvalidOperationException)
            {
                //Stack is empty so do nothing
            }
        }

        public static void Redo()
        {
            try
            {
                var command = RedoCommands.Pop();
                command.Perform();
                UndoCommands.Push(command);
            }
            catch (InvalidOperationException)
            {
                //Redo stack empty so do nothing
            }
        }

        
    }
}
