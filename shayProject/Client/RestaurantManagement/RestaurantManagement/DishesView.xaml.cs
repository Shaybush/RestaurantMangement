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
    /// Interaction logic for DishesView.xaml
    /// </summary>
    public partial class DishesView : Page
    {
        Service1Client srv = new Service1Client();
        Menuu m;
        TypeDishesList typeL;

        public DishesView()
        {
            InitializeComponent();
            srv = new Service1Client();
            FillMenu();
            typeL = srv.GetDish();
            comboD.ItemsSource = typeL;

            m = new Menuu();
        }

        private void FillMenu()
        {
            MenuList mlst = srv.GetAllDishes();
            listView1.ItemsSource = mlst;
        }
        /**
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage ());
        }
        **/
        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //m = listView1.SelectedItem as Menuu;
            //m.Type = typeL.Find(item => item.Id == m.Id);

            ////this.Dish.Visibility = Visibility.Visible;
            //this.Dish.DataContext = null;   // force refresh
            //this.Dish.DataContext = m;
            //this.UpdBtn.Visibility = Visibility.Visible;
        }

        //private void AddBtn_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void UpdBtn_Click(object sender, RoutedEventArgs e)  // update in DB
        {
            Genral.sendImage(m.Pic1); // send image to Host
            if (m.Id == 0) // add new dish
            {
                m.Id = srv.InsertDish(m);
                if (m.Id > 0)
                    FillMenu();
            }
            else  //update existing dish 
            {
                srv.UpdateDish(m);
            }

            this.Dish.DataContext = null;// grid 2
            this.UpdBtn.Visibility = Visibility.Collapsed;
            this.Dish.Visibility = Visibility.Collapsed;

        }
        //private void AddBtn_Click(object sender, RoutedEventArgs e)
        //{
        //}

        private void Update(object sender, RoutedEventArgs e)  // מעדכן מנה 
        {
            //InsertBtn.Visibility = Visibility.Collapsed;
            this.Dish.Visibility = Visibility.Visible;
            /* Service1Client*/
            //  srv = new Service1Client();
            m  /*Object o*/ = listView1.SelectedItem as Menuu; // המנה שנבחרה מהרשימה
            m.Type = typeL.Find(item => item.Id == m.Type.Id);

            //this.Dish.DataContext = null;
            this.Dish.DataContext = m;
            this.UpdBtn.Visibility = Visibility.Visible;

        }

        private void Delete(object sender, RoutedEventArgs e)  // מוחק מנה 
        {
            //  srv = new Service1Client();

            Menuu menu/* MainWindow.UserM */= (Menuu)listView1.SelectedItem; // מי שנבחר מהרשימה
            var con = MessageBox.Show("Or Not", "Delete", MessageBoxButton.YesNo);
            if (con == MessageBoxResult.Yes)// אם כן
            {
                srv.DeleteDish(menu); //(MainWindow.UserM);
                //  NavigationService.Navigate(new WorkerView()); // מיותר
                this.Dish.DataContext = null;
                this.Dish.Visibility = Visibility.Collapsed;
                FillMenu();
            }

        }
        private void PicChoice_Click(object sender, RoutedEventArgs e)
        {
            m.Pic1 = Genral.UploadImage();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)  // new Dish
        {
            m = new Menuu();
            this.Dish.DataContext = null;
            this.Dish.DataContext = m;
            this.Dish.Visibility = Visibility.Visible;
            this.UpdBtn.Visibility = Visibility.Visible;
            //WorkFrame.Navigate(new Register());
        }
    }
}