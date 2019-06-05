using Hotel.Models.DataAccess;
using Hotel.Models.Entity;
using System.Collections.Generic;
using System.Windows;

namespace Hotel.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            RoomDAL roomDAL = new RoomDAL();
            var result = roomDAL.GetRoomData(1);

            System.Console.WriteLine($"Room type: {result.Room.RoomType}");
            foreach (var item in result.Features)
            {
                System.Console.WriteLine($"Feature: {item.Name}");
            }
            foreach (var item in result.Images)
            {
                System.Console.WriteLine($"Feature: {item.Image.Length}");
            }


        }
    }
}
