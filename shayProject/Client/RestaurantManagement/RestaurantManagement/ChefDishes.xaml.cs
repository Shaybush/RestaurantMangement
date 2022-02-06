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
using System.Windows.Threading;
using RestaurantManagement.ServiceReference1;
namespace RestaurantManagement
{
    /// <summary>
    /// Interaction logic for ChefDishes.xaml
    /// </summary>
    public partial class ChefDishes : Page
    {
        DeskMenuList list;

            Service1Client srv = new Service1Client();
            DeskMenu deskM;
            JobStatusList jobs;

        public ChefDishes()
        {
            InitializeComponent();
                srv = new Service1Client();

            //       list = srv.GetDeskList(JS.מלצר);

            //   FillChefList();
            //jobs = srv.GetJobs();
            //comboD.ItemsSource = jobs;

            //deskM = new DeskMenu();
            //this.DataContext = deskM;

            //       this.chefList.ItemsSource = list;

            Timer_Tick(null, null);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 15);
            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            list = srv.GetDeskMenuList(JS.טבח);

            this.chefList.ItemsSource = null;
            this.chefList.ItemsSource = list;
        }

        private void SendToWaiter_Click(object sender, RoutedEventArgs e)
        {
            DeskMenu deskMenu = this.chefList.SelectedItem as DeskMenu;
            int x=srv.ChangeStatus(deskMenu, JS.מלצר);
            if (x > 0)//if OK
            { }
        }

        //    private void FillChefList()
        //    {
        //   DeskMenuList dml = srv.GetAllDeskMenu();
        //    chefList.ItemsSource = dml;
        //        //chefList.ItemsSource = dml;
        //        //Desk dlst = srv.GetAllDesk();
        //        //deskView.ItemsSource = dlst;
        //    }
        //private void Delete(object sender, RoutedEventArgs e)
        //{

        //    MainWindow.Table = (Desk)chefList.SelectedItem; // מי שנבחר מהרשימה
        //    var con = MessageBox.Show("Or Not", "Delete", MessageBoxButton.YesNo);
        //    if (con == MessageBoxResult.Yes)// אם כן
        //    {
        //        srv.ChangeDeskStatus(MainWindow.Table, JS.מלצר);
        //        //  NavigationService.Navigate(new WorkerView()); // מיותר
        //        FillChefList();
        //    }

        //}

        private void Button_Click(object sender, RoutedEventArgs e)  //back
        {
            if (MainWindow.User.Pos.Id==3)
            {
                NavigationService.Navigate(new ChefPage());
            }
            if (MainWindow.User.Pos.Id == 1)
            {
                NavigationService.Navigate(new JobStatus());
            }
        }
    }
    }
