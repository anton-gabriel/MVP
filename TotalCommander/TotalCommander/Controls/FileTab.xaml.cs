using System.Windows;
using System.Windows.Controls;

namespace TotalCommander.Controls
{
    /// <summary>
    /// Interaction logic for FileTab.xaml
    /// </summary>
    public partial class FileTab : UserControl
    {


        public FileTab()
        {
            InitializeComponent();

            AddHandler(Controls.FileDataGrid.ItemSelectedEvent, new RoutedEventHandler(OnItemSelected));
        }

        #region Properties
        public FileTabItem SelectedTabItem => (this.tabControl.SelectedItem as TabItem)?.DataContext as FileTabItem;
        #endregion

        private void OnItemSelected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(SelectedTabItem?.SelectedItem?.ToString());
        }

        public void NewTab()
        {
            (this.tabControl.DataContext as Model.TabManager).NewTab();
        }

        private void OnTabChanged(object sender, SelectionChangedEventArgs e)
        {
            (sender as FrameworkElement)?.RaiseEvent(new RoutedEventArgs(FileDataGrid.ItemSelectedEvent));
        }
    }
}
