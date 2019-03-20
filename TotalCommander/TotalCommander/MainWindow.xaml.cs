using System.Windows;
using System.Windows.Controls;

namespace TotalCommander
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LeftComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //LoadDirectories();
        }


        private void TreeView_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.OriginalSource as TreeViewItem;
            Model.TreeViewManager.Instance.Expand(item);

        }

        private void DataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            string path = ((Model.MemoryItem)this.dataGrid.SelectedItem)?.Path;
            if (path != null)
            {
                Model.ListViewManager.Instance.Open(path);
            }
        }
    }
}
