using System;
using System.Windows.Input;

namespace Sudoku.Commands
{
    internal sealed class RelayCommand : ICommand
    {
        private Predicate<object> canExecute;
        private Action<object> execute;

        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return this.canExecute(parameter);
        }

        void ICommand.Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
