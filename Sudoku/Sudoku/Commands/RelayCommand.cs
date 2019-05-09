using System;
using System.Windows.Input;

namespace Sudoku.Commands
{
    internal sealed class RelayCommand : ICommand
    {
        private Predicate<object> canExecute;
        private Action<object> execute;

        public RelayCommand(Action<object> execute)
        {
            this.execute = execute;
            this.canExecute = param => true;
        }
        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public event EventHandler CanExecuteChanged
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

        public bool CanExecute(object parameter)
        {
            return this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }


    internal sealed class RelayCommand<T> : ICommand
    {
        private Predicate<T> canExecute;
        private Action<T> execute;

        public RelayCommand(Action<T> execute)
        {
            this.execute = execute;
            this.canExecute = param => true;
        }
        public RelayCommand(Predicate<T> canExecute, Action<T> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public event EventHandler CanExecuteChanged
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

        public bool CanExecute(object parameter)
        {
            return this.canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            this.execute((T)parameter);
        }
    }
}