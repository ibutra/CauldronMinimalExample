using System;

namespace CauldronMinimal.History
{
    public class GenericCommand : ICommand
    {
        private readonly Action _performAction;
        private readonly Action _undoAction;
        public GenericCommand(Action performAction, Action undoAction)
        {
            _performAction = performAction;
            _undoAction = undoAction;
        }
        public void Perform()
        {
            _performAction.Invoke();
        }

        public void Undo()
        {
            _undoAction.Invoke();
        }
    }
}