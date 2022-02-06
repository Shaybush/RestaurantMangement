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
    /// Interaction logic for Bill.xaml
    /// </summary>
    public partial class Bill : Page
    {
        Desk dd;
        //DeskMenu deskMenu;
        Service1Client service = new Service1Client();


        public Bill(Desk d)
        {
            this.dd = d;
            InitializeComponent();
            //this.lstView3 = service.GetAllDishes();
            this.llabel.Content = service.GetBill(d);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            service.ChangeDeskStatus(dd, JS.מלצר);
            MessageBox.Show("מלצר בדרך אלייך");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainGuest());
        }
    }
}
