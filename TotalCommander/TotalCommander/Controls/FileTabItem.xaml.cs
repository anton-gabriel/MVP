using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace TotalCommander.Controls
{
    /// <summary>
    /// Interaction logic for FileTabItem.xaml
    /// </summary>
    /// 
    public enum FileTabType
    {
        InvalidType = 0,
        TreeViewTab,
        DataGridTab
    }

    public partial class FileTabItem : UserControl
    {
        public class TabHeader : INotifyPropertyChanged
        {

            public event PropertyChangedEventHandler PropertyChanged;

            private FileTabType fileTabType;
            #region Properties
            public string CurrentDrive { get; set; }
            public string Name
            {
                get
                {
                    switch (TabType)
                    {
                        case FileTabType.TreeViewTab:
                            return TabType.ToString();
                        case FileTabType.DataGridTab:
                            return CurrentDrive;
                        default:
                            return null;
                    }
                }
            }
            public FileTabType TabType
            {
                get => this.fileTabType;
                set
                {
                    this.fileTabType = value;
                    OnPropertyChanged("Name");
                }
            }
            #endregion

            protected void OnPropertyChanged(string name)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }


        #region Properties
        public TabHeader Header { get; set; }


        public Model.MemoryItem SelectedItem => Header.TabType == FileTabType.DataGridTab ? this.fileDataGrid.SelectedItem : null;
        public List<Model.MemoryItem> SelectedItems => Header.TabType == FileTabType.DataGridTab ? this.fileDataGrid.SelectedItems : null;
        public Model.MemoryItem CurrentDirectory => Header.TabType == FileTabType.DataGridTab ? this.fileDataGrid.CurrentDirectory : null;

        #endregion

        public FileTabItem()
        {
            InitializeComponent();

            DataContext = this;
            Header = new TabHeader();

            ActivateDataGrid(@"C:\");
        }


        #region Events
        private void LoadDrive_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string driveName = (this.comboBox.SelectedItem as Model.Drive).Name;

            ActivateDataGrid(driveName);
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            this.fileDataGrid.Back();
        }
        private void Forward(object sender, RoutedEventArgs e)
        {
            this.fileDataGrid.Next();
        }
        #endregion

        #region Public methods
        public void ActivateTreeView()
        {
            this.fileTreeView.Visibility = Visibility.Visible;
            this.fileDataGrid.Visibility = Visibility.Hidden;

            Header.TabType = FileTabType.TreeViewTab;
            RaiseEvent(new RoutedEventArgs(FileDataGrid.ItemSelectedEvent));
        }

        public void ActivateDataGrid(in string driveName)
        {
            this.fileTreeView.Visibility = Visibility.Hidden;
            this.fileDataGrid.Visibility = Visibility.Visible;

            this.fileDataGrid.OpenDrive(driveName);

            Header.CurrentDrive = driveName;
            Header.TabType = FileTabType.DataGridTab;
            RaiseEvent(new RoutedEventArgs(FileDataGrid.ItemSelectedEvent));
        }
        #endregion

    }
}
