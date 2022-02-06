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
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            WorkerList_Selected(null, null); 
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {


        }
        private void WorkerList_Selected(object sender, RoutedEventArgs e)
        {
            int i = 9;
            //  NavigationService.Navigate(new WorkerList());
            MyFrame.Navigate(new WorkerView ());

        }

        private void HamburgerMenuItem_Selected_1(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new DishesView());  
         //   int i = 9;

        }

        private void HamburgerMenuItem_Selected_2(object sender, RoutedEventArgs e)
        {
           // MyFrame .Navigate (new SearchWorker());

        }

        private void HamburgerMenuItem_Selected_3(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }

        private void HamburgerMenuItem_Selected_4(object sender, RoutedEventArgs e)
        {

            if (NavigationService.CanGoForward)
                NavigationService.GoForward();

        }

        private void W1_Selected(object sender, RoutedEventArgs e)
        {
            NavigationService .Navigate(new Login());
        }

        private void HamburgerMenuItem_Selected(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new JobStatus());
        }
    }
}
