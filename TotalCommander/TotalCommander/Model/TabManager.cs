using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace TotalCommander.Model
{
    class TabManager
    {
        public ObservableCollection<TabItem> Data { get; set; }

        public TabManager()
        {
            Initialize();
        }

        private void Initialize()
        {
            Controls.FileTabItem fileTreeViewTab = new Controls.FileTabItem();
            fileTreeViewTab.ActivateTreeView();
            //   (LogicalTreeHelper.FindLogicalNode(fileTreeViewTab, "fileDataGrid") as Controls.FileDataGrid).Visibility = Visibility.Hidden;

            Controls.FileTabItem fileDataGridTab = new Controls.FileTabItem();
            fileDataGridTab.ActivateDataGrid(@"C:\");

            Data = new ObservableCollection<TabItem>
            {
               fileTreeViewTab.tabItem,
               fileDataGridTab.tabItem
            };
        }

        public void NewTab()
        {
            Data.Add(new Controls.FileTabItem().tabItem);

        }
    }
}
