using System.Windows;
using System.Windows.Controls;

namespace TotalCommander
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LeftComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //LoadDirectories();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Model.ListViewManager.Instance.Back();
           
                if (contentControl1.Template == Resources["gridVertical"])
                    contentControl1.Template = (ControlTemplate)Resources["gridHorizontal"];
                else
                    contentControl1.Template = (ControlTemplate)Resources["gridVertical"];
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           // Model.ListViewManager.Instance.Next();
        }
     
    }
}
