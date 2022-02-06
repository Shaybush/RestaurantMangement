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
using RestaurantManagement.ServiceReference1;

namespace RestaurantManagement
{
    /// <summary>
    /// Interaction logic for MainGuest.xaml
    /// </summary>
    public partial class MainGuest : Page
    {
        Service1Client srv = new Service1Client();
        public MainGuest()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)  // show menu
        {
            NavigationService.Navigate(new DishView2());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            srv.WaitingWaiter(MainWindow.Table);
            this.HelpClick.Visibility = Visibility.Collapsed;
            //Desk.jobStatus.id = 2;
            this.WaiterHelp.Visibility = Visibility.Visible;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Bill(MainWindow.Table));
        }
    }
}
