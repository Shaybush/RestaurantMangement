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
    /// Interaction logic for DishUC.xaml
    /// </summary>
    public partial class DishUC : UserControl
    {

        //  public delegate void SpeedDelegate(int newSpeed);
     public   event EventHandler Selected;
        Service1Client srv = new Service1Client();
        TypeDishesList typeL;
        private  Menuu menu;
        public Menuu Menu { get => menu; set => menu = value; }

        //public string Kuku()
        //{
        //    return this.menu.FoodName; 

        //}
        private void UserConrol_Click(object sender, RoutedEventArgs e) //מוסיף את המנה לשולחן 
        {
            //DishView2.addUC(menu);
            
        }
            public string Kuku
        {
            get { return this.menu.FoodName+"   "+this.menu.Price+"   "+this.menu.Type.Ty+"   "+this.menu.Information; }
            set {
                this.menu.FoodName = value; } 
            }


        public DishUC()
        {

            InitializeComponent();
        }

        public DishUC(Menuu menu):this()
        {
            this.menu = menu;
            this.DataContext = this;
        }


       

       
        private void UserConrol_Click(object sender, MouseButtonEventArgs e)
        {
 if (Selected != null)
                Selected(menu, null);
        }
    }
}



