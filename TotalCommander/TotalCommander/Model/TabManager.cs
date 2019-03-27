using System.Collections.ObjectModel;
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
            Controls.FileTabItem fileDataGridTab = new Controls.FileTabItem();

            Data = new ObservableCollection<TabItem>
            {
               fileDataGridTab.tabItem
            };
        }

        public void NewTab()
        {
            Data.Add(new Controls.FileTabItem().tabItem);
        }
    }
}
