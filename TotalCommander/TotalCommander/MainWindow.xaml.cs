using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
            InitializeGridDefinitions();
            foreach (ColumnDefinition columnDefinition in this.columnDefinitions)
            {
                this.CentralGrid.ColumnDefinitions.Add(columnDefinition);
            }
            this.verticalArrangement = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

    }
}
