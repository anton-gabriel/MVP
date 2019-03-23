using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TotalCommander.Controls
{
    /// <summary>
    /// Interaction logic for FileDataGrid.xaml
    /// </summary>
    public partial class FileDataGrid : UserControl
    {
        public FileDataGrid()
        {
            InitializeComponent();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.dataGrid.SelectedItem is Model.MemoryItem item)
            {
                (this.dataGrid.DataContext as Model.ListViewManager).Open(item);
            }
        }
    }
}
