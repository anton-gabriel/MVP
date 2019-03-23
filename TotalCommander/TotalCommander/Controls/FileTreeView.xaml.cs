using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TotalCommander.Controls
{
    /// <summary>
    /// Interaction logic for FileTreeView.xaml
    /// </summary>
    public partial class FileTreeView : UserControl
    {
        public FileTreeView()
        {
            InitializeComponent();
        }

        private void TreeView_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.OriginalSource as TreeViewItem;
            (this.treeView.DataContext as Model.TreeViewManager).Expand(item);
        }
    }
}
