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
        }
        
        public void NewTab()
        {
            (tabControl.DataContext as Model.TabManager).NewTab();
        }

    }
}
