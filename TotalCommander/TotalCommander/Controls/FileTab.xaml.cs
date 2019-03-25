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
 
            //(this.tabControl.DataContext as Model.TabManager).TabItem = this.tabControl.SelectedItem as TabItem;
           //(this.tabControl.DataContext as Model.TabManager).NewTab();
        }
        
        public void NewTab()
        {
            //(tabControl.DataContext as Model.TabManager)
        }

    }
}
