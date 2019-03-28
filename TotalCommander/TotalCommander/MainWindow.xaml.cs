using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace TotalCommander
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<ColumnDefinition> columnDefinitions;
        List<RowDefinition> rowDefinitions;
        bool verticalArrangement;

        public Controls.FileTab SelectedTab { get; set; } = null;
        public Controls.FileTab UnselectedTab { get; set; } = null;

        private void InitializeGridDefinitions()
        {
            this.columnDefinitions = new List<ColumnDefinition>();
            this.rowDefinitions = new List<RowDefinition>();

            this.columnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            this.columnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(5, GridUnitType.Pixel) });
            this.columnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            this.rowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            this.rowDefinitions.Add(new RowDefinition() { Height = new GridLength(5, GridUnitType.Pixel) });
            this.rowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
        }

        public MainWindow()
        {
            InitializeComponent();

            AddHandler(Controls.FileDataGrid.ItemSelectedEvent, new RoutedEventHandler(OnItemSelected));
            InitializeGridDefinitions();
            foreach (ColumnDefinition columnDefinition in this.columnDefinitions)
            {
                this.CentralGrid.ColumnDefinitions.Add(columnDefinition);
            }
            this.verticalArrangement = false;
        }

        private void OnItemSelected(object sender, RoutedEventArgs e)
        {
            Model.MemoryItem item = (e.OriginalSource as DataGrid)?.SelectedItem as Model.MemoryItem;

            LoadButtons(item);
            e.Handled = true;
        }

        private void LoadButtons(in Model.MemoryItem item)
        {
            bool enabled = item != null && SelectedTab != null;

            //Edit merge doar pe file
            if (item is Model.File)
            {
                this.editButton.IsEnabled = enabled;
            }
            else
            {
                this.editButton.IsEnabled = false;
            }
            this.viewButton.IsEnabled = enabled;
            this.copyButton.IsEnabled = enabled;
            this.moveButton.IsEnabled = enabled;
            this.newFolderButton.IsEnabled = SelectedTab?.SelectedTabItem.Header.TabType == Controls.FileTabType.DataGridTab;
            this.deleteButton.IsEnabled = enabled;

            this.packMenuItem.IsEnabled = enabled;
            this.unpackMenuItem.IsEnabled = enabled;
            this.compareMenuItem.IsEnabled = this.leftControl.SelectedTabItem?.SelectedItem != null &&
                this.rightControl.SelectedTabItem?.SelectedItem != null;
            this.fullViewMenuItem.IsEnabled = SelectedTab != null;
            this.treeViewMenuItem.IsEnabled = SelectedTab != null;
            this.newTabMenuItem.IsEnabled = SelectedTab != null;
        }

        private void RightControl_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SelectedTab = this.rightControl;
            SelectedTab.Enable();
            UnselectedTab = this.leftControl;
            UnselectedTab.Disable();
            LoadButtons(SelectedTab.SelectedTabItem?.SelectedItem);
            e.Handled = true;
        }

        private void LeftControl_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SelectedTab = this.leftControl;
            SelectedTab.Enable();
            UnselectedTab = this.rightControl;
            UnselectedTab.Disable();
            LoadButtons(SelectedTab.SelectedTabItem?.SelectedItem);
            e.Handled = true;
        }

        #region CommandMenu
        private void View_Button(object sender, RoutedEventArgs e)
        {
            Model.MemoryItem.ViewItems(SelectedTab.SelectedTabItem?.SelectedItems);
        }

        private void Edit_Button(object sender, RoutedEventArgs e)
        {

        }

        private void Copy_Button(object sender, RoutedEventArgs e)
        {
            Model.MemoryItem.CopyItems(SelectedTab.SelectedTabItem?.SelectedItems,
                UnselectedTab.SelectedTabItem?.CurrentDirectory);
        }
        private void Move_Button(object sender, RoutedEventArgs e)
        {
            Model.MemoryItem.MoveItems(SelectedTab.SelectedTabItem?.SelectedItems,
                UnselectedTab.SelectedTabItem?.CurrentDirectory);
        }
        private void NewFolder_Button(object sender, RoutedEventArgs e)
        {
            Model.MemoryItem.CreateDirectory(SelectedTab.SelectedTabItem?.CurrentDirectory);
        }
        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            Model.MemoryItem.DeleteItems(SelectedTab.SelectedTabItem?.SelectedItems);
        }
        #endregion

        #region Command Keyboard

        private void Command_Keyboard(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case System.Windows.Input.Key.F3:
                    if (this.viewButton.IsEnabled)
                    {
                        Model.MemoryItem.ViewItems(SelectedTab.SelectedTabItem?.SelectedItems);
                    }
                    break;
                case System.Windows.Input.Key.F4:
                    break;
                case System.Windows.Input.Key.F5:
                    if (this.copyButton.IsEnabled)
                    {
                        Model.MemoryItem.CopyItems(SelectedTab.SelectedTabItem?.SelectedItems,
                        UnselectedTab.SelectedTabItem?.CurrentDirectory);
                    }
                    break;
                case System.Windows.Input.Key.F6:
                    if (this.moveButton.IsEnabled)
                    {
                        Model.MemoryItem.MoveItems(SelectedTab.SelectedTabItem?.SelectedItems,
                        UnselectedTab.SelectedTabItem?.CurrentDirectory);
                    }
                    break;
                case System.Windows.Input.Key.F7:
                    if (this.newFolderButton.IsEnabled)
                    {
                        Model.MemoryItem.CreateDirectory(SelectedTab.SelectedTabItem?.CurrentDirectory);
                    }
                    break;
                case System.Windows.Input.Key.F8:
                    if (this.deleteButton.IsEnabled)
                    {
                        Model.MemoryItem.DeleteItems(SelectedTab.SelectedTabItem?.SelectedItems);
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region AppMenu
        private void OpenLink(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
        private void FullView_Click(object sender, RoutedEventArgs e)
        {
            SelectedTab.SelectedTabItem?.ActivateDataGrid(@"C:\");
            LoadButtons(SelectedTab.SelectedTabItem?.SelectedItem);
        }
        private void TreeView_Click(object sender, RoutedEventArgs e)
        {
            SelectedTab.SelectedTabItem?.ActivateTreeView();
            LoadButtons(SelectedTab.SelectedTabItem?.SelectedItem);
        }
        private void VerticalView_Click(object sender, RoutedEventArgs e)
        {
            if (this.verticalArrangement)
            {
                this.CentralGrid.RowDefinitions.Clear();
                foreach (ColumnDefinition columnDefinition in this.columnDefinitions)
                {
                    this.CentralGrid.ColumnDefinitions.Add(columnDefinition);
                }
                this.verticalArrangement = false;
            }
            else
            {
                this.CentralGrid.ColumnDefinitions.Clear();
                foreach (RowDefinition rowDefinition in this.rowDefinitions)
                {
                    this.CentralGrid.RowDefinitions.Add(rowDefinition);
                }
                this.verticalArrangement = true;
            }
        }
        private void NewTab_Click(object sender, RoutedEventArgs e)
        {
            SelectedTab.NewTab();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Pack_Click(object sender, RoutedEventArgs e)
        {
            Model.MemoryItem.PackItems(SelectedTab?.SelectedTabItem?.SelectedItems, UnselectedTab?.SelectedTabItem?.CurrentDirectory);
        }
        private void Unpack_Click(object sender, RoutedEventArgs e)
        {
            Model.MemoryItem.UnpackItems(SelectedTab?.SelectedTabItem?.SelectedItems, UnselectedTab?.SelectedTabItem?.CurrentDirectory);
        }
        private void Compare_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "Compare by content",
                Content = new Controls.FileComparator(this.leftControl.SelectedTabItem?.SelectedItem,
                this.rightControl.SelectedTabItem?.SelectedItem)
            };

            window.ShowDialog();
        }

        #endregion


    }
}
