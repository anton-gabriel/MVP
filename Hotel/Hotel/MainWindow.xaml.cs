using Hotel.Models.Entity;
using Hotel.Services;
using Hotel.Services.UnitOfWork;
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

namespace Hotel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                // Example1
                unitOfWork.Users.Add(new User()
                {
                    UserType = UserType.Client,
                    FirstName = "Test",
                    LastName = "test",
                    Password = "12345",
                });


                unitOfWork.Complete();
            }
        }
    }
}
