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
    /// Interaction logic for DeskView.xaml
    /// </summary>
    public partial class DeskView : Page
    {
        
        Service1Client srv = new Service1Client();
        Desk desk;
        JobStatusList jobs;
        
        public DeskView()
        {
            InitializeComponent();
            srv = new Service1Client();
            FillDishes();
            jobs = srv.GetJobs();
            //comboD.ItemsSource = jobs;

            desk = new Desk();
            


        }

        private void FillDishes()
        {
            DeskList dlst = srv.GetAllDesks();
            dW.ItemsSource = null;
            dW.ItemsSource = dlst;
            //Desk dlst = srv.GetAllDesk();
            //deskView.ItemsSource = dlst;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.User.Pos.Id == 1)
            {
                NavigationService.Navigate(new JobStatus());
            }
            else
            NavigationService.Navigate(new WaiterPage());
        }
    }
    }

