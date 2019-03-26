using System.IO;
using System.Windows.Controls;
using System.Windows.Input;

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

        public void OpenDrive(in string driveName)
        {
            (this.dataGrid.DataContext as Model.ListViewManager).Open(Model.ListViewManager.CreateChild(new DriveInfo(driveName)));
        }
    }
}
