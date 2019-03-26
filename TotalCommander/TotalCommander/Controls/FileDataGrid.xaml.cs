using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TotalCommander.Controls
{
    /// <summary>
    /// Interaction logic for FileDataGrid.xaml
    /// </summary>
    public partial class FileDataGrid : UserControl
    {

        public static readonly RoutedEvent ItemSelectedEvent = EventManager.RegisterRoutedEvent("ItemSelectedEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FileDataGrid));
        // Provide CLR accessors for the event
        public event RoutedEventHandler ItemSelected
        {
            add { AddHandler(ItemSelectedEvent, value); }
            remove { RemoveHandler(ItemSelectedEvent, value); }
        }




        public FileDataGrid()
        {
            InitializeComponent();
        }

        #region Properties
        public Model.MemoryItem SelectedItem => this.dataGrid.SelectedItem as Model.MemoryItem;
        
        #endregion

        #region Events
        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.dataGrid.SelectedItem is Model.MemoryItem item)
            {
                (this.dataGrid.DataContext as Model.ListViewManager).Open(item);
            }
        }
        #endregion

        #region Public methods
        public void OpenDrive(in string driveName)
        {
            (this.dataGrid.DataContext as Model.ListViewManager).Open(Model.ListViewManager.CreateChild(new DriveInfo(driveName)));
        }
        #endregion

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("S-a apelat selection");
            e.Handled = true;
            (sender as FrameworkElement)?.RaiseEvent(new RoutedEventArgs(ItemSelectedEvent));
        }
    }
}
