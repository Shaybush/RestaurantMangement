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
using System.Windows.Shapes;
using RestaurantManagement.ServiceReference1;

using System.Windows.Threading;


namespace RestaurantManagement
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class DeskView2 : Page
    {
      Service1Client service = new Service1Client();
        Worker w;

        public DeskView2(Worker w)
        {
            InitializeComponent();
            this.w = w;


            DeskList list = service.GetAllDesks();  // מהזכרון

            foreach (Desk desk in list)
            {
            DeskUC  us = new DeskUC(desk);
                us.Margin = new Thickness(10);
            us.Select += Us_Select;
               
            pnl.Children.Add(us);
            }

            DispatcherTimer orderrefresh = new DispatcherTimer();
            orderrefresh.Tick += Orderrefresh_Tick;
            orderrefresh.Interval = new TimeSpan(0, 0, 5);
            orderrefresh.Start();


        }

        private void Orderrefresh_Tick(object sender, EventArgs e)
        {
            pnl.Children.Clear();
            DeskList list = service.GetAllDesks();  // מהזכרון

            foreach (Desk desk in list)
            {
                DeskUC us = new DeskUC(desk);
                us.Margin = new Thickness(10);
                us.Select += Us_Select;
                pnl.Children.Add(us);
            }
        }

        private void Us_Select(object sender, EventArgs e)
        {
            //   Tables t=   (Tables)sender;
            //Window win = new ETable(t);
            //win.ShowDialog();
           
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //if (w == null)
            //{
            //    //Window win = new ManagerM();
            //    //win.Show();
            //    //this.Close();
            //}

            //else
            //{
            //    //Window win1 = new MyWorker(w);
            //    //win1.Show();
            //    //this.Close();
            //}
            NavigationService.Navigate(new WaiterPage());
        }
    }
}
