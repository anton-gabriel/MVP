using Hotel.Commands;
using Hotel.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.ViewModels
{
    internal class MainViewModel
    {

        #region Commands
        private RelayCommand<object> continueCommand;
        public RelayCommand<object> ContinueCommand
        {
            get
            {
                if (this.continueCommand == null)
                {
                    this.continueCommand = new RelayCommand<object>(Continue);
                }
                return this.continueCommand;
            }
        }
        #endregion

        #region Private methods
        private void Continue(object window)
        {
            UserView userView = new UserView();
            userView.Show();
            (window as Window)?.Close();
        }
        #endregion
    }
}
