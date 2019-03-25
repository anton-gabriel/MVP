using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Markup;
using System.IO;
using System.Xml;

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
            Data = new ObservableCollection<TabItem>
            {
                new Controls.FileTabItem().tabItem,
                new Controls.FileTabItem().tabItem,
                new Controls.FileTabItem().tabItem,
            };
        }
        public TabItem CreateTabItem(in TabItem tabItem)
        {
            string savedItem = XamlWriter.Save(tabItem);

            // Load the button
            StringReader stringReader = new StringReader(savedItem);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            return (TabItem)XamlReader.Load(xmlReader);
        }

        private TabItem CreateTabItem()
        {
            #region Comment
            Grid grid = new Grid();

            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            ComboBox comboBox = new ComboBox()
            {
            };
            comboBox.DataContext = new Model.Driver();
            comboBox.ItemsSource = (comboBox.DataContext as Model.Driver).Drives;
            comboBox.SetValue(Grid.RowProperty, 0);
            grid.Children.Add(comboBox);

            Grid innerGrid = new Grid();
            Controls.FileTreeView fileTreeView = new Controls.FileTreeView();
            innerGrid.SetValue(Grid.RowProperty, 1);
            innerGrid.Children.Add(fileTreeView);
            grid.Children.Add(innerGrid);

            Grid test = new Grid();
        

            return new TabItem()
            {
                Content = grid,
                Header = "Test",
                Name = "Test",
            };
            #endregion

        }

        public void NewTab()
        {
          
        }
    }
}
