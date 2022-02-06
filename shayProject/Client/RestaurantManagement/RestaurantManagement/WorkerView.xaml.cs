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
    /// Interaction logic for WorkerView.xaml
    /// </summary>
    public partial class WorkerView : Page
    {

        Service1Client service = new Service1Client();
        Worker w;
      //  PositionList posList;
        public WorkerView()
        {
            InitializeComponent();
            service = new Service1Client();
            FillWorkers();
         //   posList = service.GetPosition();
            //RegisterUC.combox.ItemsSource = posList;

            w = new Worker();
           // this.DataContext = w;
        }

        private void FillWorkers()
        {

            WorkerList wlst = service.GetAll();
            //WorkerDB s=
            //hgfhj.DataContext = w;
            listView.ItemsSource = wlst;
        }


       
        private void Update(object sender, RoutedEventArgs e)
        {
            this.AddBtn.Visibility = Visibility.Collapsed ;
            this.registerUC.Visibility = Visibility.Visible;
            /* Service1Client*/
         //   service = new Service1Client();
            w/*Object o*/ = listView.SelectedItem as Worker; // העובד שנבחר מהרשימה

            this.registerUC.DataContext = w;
            this.UpdBtn.Visibility = Visibility.Visible;


        }
        private void UpdBtn_Click(object sender, RoutedEventArgs e)  
        {
           
                service.UpdateWorker(w);
            
            this.registerUC.DataContext = null;// grid 2
            this.UpdBtn.Visibility = Visibility.Collapsed;
            this.registerUC.Visibility = Visibility.Collapsed ;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {

            MainWindow.User = (Worker)listView.SelectedItem; // מי שנבחר מהרשימה
            var con = MessageBox.Show("Or Not", "Delete", MessageBoxButton.YesNo);
            if (con == MessageBoxResult.Yes)// אם כן
            {
                service.DeleteWorker (MainWindow.User);
                //  NavigationService.Navigate(new WorkerView()); // מיותר
                FillWorkers();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)  // Add Worker
        {
            w = new Worker();
            this.registerUC.DataContext = null;
            this.registerUC.DataContext = w;

            this.registerUC.Visibility = Visibility.Visible;
            this.AddBtn.Visibility = Visibility.Visible;
            //WorkFrame.Navigate(new Register());
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
          //  this.DataContext = w;
            if (w.Id == 0)
            {
                w.Id = service.InsertWorker(w);
            }


            if (w.Id > 0)  //if OK
            {
                FillWorkers();
            }

            this.registerUC.DataContext = null;// grid 2
            this.AddBtn.Visibility = Visibility.Collapsed;
            this.registerUC.Visibility = Visibility.Collapsed;
        }
    }
}
