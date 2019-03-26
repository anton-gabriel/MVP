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
        public enum SelectedTab
        {
            None = 0,
            Left,
            Right
        }

        List<ColumnDefinition> columnDefinitions;
        List<RowDefinition> rowDefinitions;
        bool verticalArrangement;

        public SelectedTab Selected { get; set; } = SelectedTab.None;

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
            bool enabled = item != null;

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
            this.newFolderButton.IsEnabled = enabled;
            this.deleteButton.IsEnabled = enabled;

            e.Handled = true;
        }

        private void RightControl_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Selected = SelectedTab.Right;
            e.Handled = true;
        }

        private void LeftControl_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Selected = SelectedTab.Left;
            e.Handled = true;
        }

        #region CommandMenu
        private void View_Button(object sender, RoutedEventArgs e)
        {
            switch (Selected)
            {
                case SelectedTab.None:
                    MessageBox.Show("No tab selected");
                    break;
                case SelectedTab.Left:
                    Process.Start(this.leftControl.SelectedTabItem?.SelectedItem.Path);
                    break;
                case SelectedTab.Right:
                    Process.Start(this.rightControl.SelectedTabItem?.SelectedItem.Path);
                    break;
                default:
                    break;
            }
        }

        private void Edit_Button(object sender, RoutedEventArgs e)
        {

        }

        private void Copy_Button(object sender, RoutedEventArgs e)
        {

        }

        private void Move_Button(object sender, RoutedEventArgs e)
        {

        }

        private void NewFolder_Button(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {

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
            switch (Selected)
            {
                case SelectedTab.None:
                    MessageBox.Show("No tab selected");
                    break;
                case SelectedTab.Left:
                    this.leftControl.SelectedTabItem?.ActivateDataGrid(@"C:\");
                    break;
                case SelectedTab.Right:
                    this.rightControl.SelectedTabItem?.ActivateDataGrid(@"C:\");
                    break;
                default:
                    break;
            }
        }

        private void TreeView_Click(object sender, RoutedEventArgs e)
        {
            switch (Selected)
            {
                case SelectedTab.None:
                    MessageBox.Show("No tab selected");
                    break;
                case SelectedTab.Left:
                    this.leftControl.SelectedTabItem?.ActivateTreeView();
                    break;
                case SelectedTab.Right:
                    this.rightControl.SelectedTabItem?.ActivateTreeView();
                    break;
                default:
                    break;
            }
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
            switch (Selected)
            {
                case SelectedTab.None:
                    MessageBox.Show("No tab selected");
                    break;
                case SelectedTab.Left:
                    this.leftControl.NewTab();
                    break;
                case SelectedTab.Right:
                    this.rightControl.NewTab();
                    break;
                default:
                    break;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        #endregion

    }
}
