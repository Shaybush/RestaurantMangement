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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)  //admin
        {
            userBox.Text = "shaybush";
            passBox.Password = "123456";
            button3_Click(null, null);
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)  //waiter
        {
            userBox.Text = "sahar";
            passBox.Password = "1234";
            button3_Click(null, null);

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)//ceff
        {
            userBox.Text = "sharon1";
            passBox.Password = "ss11";
            button3_Click(null, null); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService .Navigate (new Register  () );
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Service1Client service = new Service1Client();
            Worker worker = service.LoginWorker(userBox.Text, passBox.Password);
            if (worker == null)// אם אין משתמש כזה
            {
                textBlock.Visibility = Visibility.Visible;
                textBlock.Text = "שם משתמש או הסיסמא לא נכונים, נסה שנית";
            }
            if (worker != null)// אם יש כזה 
            {
                MainWindow.User = worker;
              //  if (!MainWindow.User.Name.Equals ("eli"))// אם הוא לא אדמין 

                if (MainWindow.User.Pos.Id == 3)  // אם הוא שף
                {
                    MessageBox.Show("hello" + ":" + MainWindow.User.Name); // + "Boby");
                    changeSize();
                    NavigationService.Navigate(new ChefPage());
                }

                if (MainWindow.User.Pos.Id == 2)  // אם הוא מלצר
                {
                    MessageBox.Show("hello" + ":" + MainWindow.User.Name); // + "Boby");
                    changeSize();
                    NavigationService.Navigate(new WaiterPage());
                }
                if(MainWindow.User.Pos.Id==1) // אם הוא אדמין
                {
                    MessageBox.Show("hello" + ":" + MainWindow.User.Name);
                    changeSize();
                    NavigationService.Navigate(new AdminPage());
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Guest());
        }

        private void changeSize() {
            this.Width = 700;
            this.Height = 1200;

        }

    }
}

