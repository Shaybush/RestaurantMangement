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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        Service1Client service = new Service1Client();
        Worker w;
        public Register()
        {

            InitializeComponent();
            combox.ItemsSource = service.GetPosition();

            w = new Worker();
            this.DataContext = w;
            if (w != null)
            {
                ButLogin.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login()); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

           // Worker w = new Worker();
            //w.Name = textBox1.Text;
            //w.Password1 = textBox2.Password;
            //w.UserName1 = textBox3.Text;

            service.InsertWorker(w);
            NavigationService.Navigate(new Login());
    
            





        }
    }
}
