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
    /// Interaction logic for Guest.xaml
    /// </summary>
    public partial class Guest : Page
    {
        Service1Client srv =new Service1Client();
        int n;
        public Guest()
        {
            InitializeComponent();
            this.DataContext = this;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Desk desk;
             n = int.Parse(textdesk.Text);  // מספר הסועדים
            desk = srv.GetFreeDesk(n); // מחפש שולחן פנוי המתאים למספר הסועדים
            if (desk == null)
                errorMsg.Content = "אין שולחן פנוי כרגע!!";
            else
            { 
            //MainWindow.table.Job.Id = 8;
         //   srv.ChangeDeskStatus(desk,JS.תפוס);
            MainWindow.Table = desk;

            NavigationService.Navigate(new MainGuest());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // או מספר שולחן או מספר סועדים בשולחן
            // איך עושים את זה
        }
    }
}
