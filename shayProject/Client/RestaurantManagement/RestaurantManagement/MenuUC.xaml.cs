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
    /// Interaction logic for MenuUC.xaml
    /// </summary>
    public partial class MenuUC : UserControl
    {
        Menuu menu;

        public Menuu Menu { get => menu; set => menu = value; }

        public   event EventHandler Selected;

        public MenuUC()
        {
            InitializeComponent();
        }

        public MenuUC(Menuu menu) :this()
        {
            this.menu = menu;
            this.DataContext = menu;
        }


    }
}
