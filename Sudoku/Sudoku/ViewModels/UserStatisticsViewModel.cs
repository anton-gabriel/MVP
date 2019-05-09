using Sudoku.Commands;
using Sudoku.Models.User;
using Sudoku.Models.Utils;
using System.Windows;
using System.Windows.Input;

namespace Sudoku.ViewModels
{
    internal class UserStatisticsViewModel : NotifyPropertyChanged
    {
        #region Constructors
        public UserStatisticsViewModel()
        {

        }
        #endregion

        #region Private fields
        private User user;
        #endregion

        #region Properties
        public User User
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged(propertyName: nameof(User));
            }
        }
        #endregion

        #region Commands
        private ICommand exitCommand;

        public ICommand ExitCommand
        {
            get
            {
                if (this.exitCommand == null)
                {
                    this.exitCommand = new RelayCommand<Window>(CloseWindow);
                }
                return this.exitCommand;
            }
        }
        #endregion


        #region Private methods
        private void CloseWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
        #endregion
    }
}
