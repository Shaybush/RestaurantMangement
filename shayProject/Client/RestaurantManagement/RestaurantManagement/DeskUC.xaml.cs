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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class DeskUC : UserControl
    {
       private static JobStatusList statusList;
       static   Service1Client service = new Service1Client();
       private  Desk desk;

        private int state;

        public event EventHandler Select;


        public int State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }

        public Desk Desk
        {
            get
            {
                return desk;
            }

            set
            {
                desk = value;
            }
        }

        //בנאי סטטי
        static DeskUC()
        {
            //      Service1Client service = new Service1Client();
            statusList = service.GetJobs();
        }

        public DeskUC()
        {
            InitializeComponent();

            //this.textBlock1.Text = this.tb.NumPeople.toString();

        }
           public DeskUC(Desk desk):this()
        {

            this.desk = desk;
            this.DataContext = this;

            //this.textBlock1.Text = this.tb.NumPeople.toString();
        }

        private void kuku_Click(object sender, RoutedEventArgs e)
        {
            //Window win = new DeskUpdWin(this.desk);   // עדכון מצב שולחן
            //win.ShowDialog();

            if (Select != null)
                Select(desk, null);
        }

        private void kuku_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.desk.Job = statusList.Find(s => s.Id == (this.desk.Job.Id));
            if (this.desk.Job == null) this.desk.Job = statusList[0];
           
        }

        public string DeskToolTip
        {

            get
            {
                return "שולחן: " + this.desk.NumDesk1 + "\nסועדים: " + this.desk.Size + "\n" +  this.desk.Job.Situation1;
            }
        }
    }


}
