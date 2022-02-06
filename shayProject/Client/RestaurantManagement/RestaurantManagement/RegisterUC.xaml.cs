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
    /// Interaction logic for RegisterUC.xaml
    /// </summary>
    public partial class RegisterUC : UserControl
    {
     //   public event EventHandler RegClicked;

        Service1Client service = null;// new Service1Client();
        private Worker w;
        public Worker Worker { get { return w; } }

        private PositionList posList;
      
        public RegisterUC()
        {
            InitializeComponent();
            if (!System .ComponentModel .DesignerProperties .GetIsInDesignMode (this))  
            { 
                service = new Service1Client();

                posList = service.GetPosition();
                combox.ItemsSource = posList;
          }
    
/*
            if (DataContext == null) // אז תייצר אותו
            {
                   w = new Worker();
            }
            */
         //   this.DataContext = w;
           
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            w = this.DataContext as Worker;
            if (w != null && w.Pos != null)
            {
                w.Pos = posList.Find(item => item.Id == w.Pos.Id);
            }
        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //  //w.Id =  service.InsertWorker(w);
        //  //  //if (w.Id>0)

        //        if (RegClicked != null)
        //        {
        //        RegClicked(this, EventArgs.Empty);
        //        }


        //}
    }
}
