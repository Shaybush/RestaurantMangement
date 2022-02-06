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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
      
    {
        public static Worker User { get; set; }
        public static Menuu UserM { get; set; }
        public static Desk Table { get; set; }
       
        

        public MainWindow()
        {
            InitializeComponent();
            frame.Navigate(new Login());
           
        }

        private void frame_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.Content is AdminPage)
            {
                this.Width = 700;
                this.Height = 450;
            }
        }
        /**
       private void Button_Click(object sender, RoutedEventArgs e)
       {
           
       }

       private void Button_Click_1(object sender, RoutedEventArgs e)
       {
           frame.Navigate(new Login());
       }

       private void Button_Click_2(object sender, RoutedEventArgs e)
       {  // מיותר - פה תמיד אין כפתורים
           //frame.Navigate(new AdminPage());//לשאול את דורית איך להסתיר את הכפתור ההתחלתי של אדמין
           //if(User!=null)
           //{
           //    this.kuku.Visibility = Visibility.Collapsed;
           //}
       }

       private void Button_Click_3(object sender, RoutedEventArgs e)
       {
          if(frame.CanGoBack)
           {
               frame.GoBack();
           }
       }

       private void Button_Click_4(object sender, RoutedEventArgs e)
       {
           if(frame.CanGoForward)
           {
               frame.GoForward(); 
           }
       }
   **/
    }
}
