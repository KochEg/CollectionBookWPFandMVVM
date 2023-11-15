using System;
using System.Windows.Input;

namespace CollectionBookWPF.Models.Command
{
    class CommandHandler : ICommand
    {
        private Action<object> _Execute;
        private Func<object, bool> _Can_Execute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value;}
        }

        public CommandHandler(Action<object> execute, Func<object, bool> can_execute = null)
        {
            _Execute = execute;
            _Can_Execute = can_execute;
        }

        public bool CanExecute(object? parameter)
        {
            return _Can_Execute == null || _Can_Execute(parameter);
        }

        public void Execute(object? parameter)
        {
            _Execute(parameter);
        }
    }
}
