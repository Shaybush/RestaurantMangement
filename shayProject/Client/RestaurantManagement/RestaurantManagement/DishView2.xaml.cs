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
    /// Interaction logic for DishView2.xaml
    /// </summary>
    public partial class DishView2 : Page
    {
        Service1Client srv = new Service1Client();
        MenuList mlst=new MenuList ();
        MenuList ordMList= new MenuList();
        DeskMenuList tempMlst = new DeskMenuList(); 

        Menuu m;
        double totalPrice =0;

        public DishView2() // הצגה שנייה של המנות (לשולחן)
        {
           InitializeComponent();

            srv = new Service1Client();

            BuildRadio();


             mlst = srv.GetAllDishes();

            
            foreach (Menuu m in mlst)
            {
                DishUC uc = new DishUC(m);
                uc.Margin = new Thickness(10);
                uc.Selected += Uc_Selected;
                pnl.Children.Add(uc);
                CheckBox check = new CheckBox();
                //if(uc.Btn.Click!=false)
                {
                    
                }
            }


           

        }
      

        private void BuildRadio()
        {

            TypeDishesList lst = srv.GetDish();
           
            foreach (TypeDishes ty in lst)
            {
                //< RadioButton x: Name = "firstMeal" Content = "firstMeal" FontSize = "20" GroupName = "Dishes" Checked = "firstMealChange"
                //                      Margin = "0,0,0,20" />

                RadioButton r = new RadioButton();
                r.Name = ty.Ty;
                r.Content = ty.Ty;
                r.FontSize = 20;
                r.GroupName = "Dishes";
                r.Margin = new Thickness(0, 0, 0, 20);
                r.Checked += FillDishesUC;
                r.Tag = ty;
                this.RadioPnl.Children.Add(r);
            }
        }
        //private void UserConrol_Click(object sender, RoutedEventArgs e) //מוסיף את המנה לשולחן 
        //{
        //    srv.AddDishToDesk(m, MainWindow.table);

        //}
        //private void FillOrder()
        //{
        //    //List<DeskMenu> deskM = srv.GetDeskList(MainWindow.table);
        //}


            private void FillDishesUC (object sender, RoutedEventArgs e)
        {
            pnl.Children.Clear();
            List<Menuu> mmm = mlst.FindAll(item => item.GlutenFree == this.Gluten.IsChecked).ToList(); // כל המנות שהן עם/ללא גלוטן
          
            foreach (Control ctrl in RadioPnl.Children)
            {
                
                RadioButton radio = ctrl as RadioButton;
                

                if (radio != null)
                {
                    
                    if (radio.IsChecked==true)
                        if((radio .Tag as TypeDishes).Id==5)
                        {
                            pnl.Children.GetType();
                        }
                    else
                           mmm = mmm.FindAll(item => item.Type.Id == (radio.Tag as TypeDishes).Id ).ToList();
                }
            }


          

            foreach (Menuu m in mmm)
            {
                DishUC uc = new DishUC(m);
                uc.Margin = new Thickness(10);
                uc.Selected += Uc_Selected;
                pnl.Children.Add(uc);
            }

        }

        private void Uc_Selected(object sender, EventArgs e)
        {
            Menuu  menu = sender as Menuu;  // למקרה שהוא נבחר תוסיף את המנה לרשית המנות של השולחן
            this.ordMList.Add(menu);
            this.tempMlst.Add(new DeskMenu() {Desk=MainWindow.Table, Menu= menu,Stat=JS.טבח ,Amount=1});

            //srv.AddDishToDesk(uc.menu, MainWindow.Table);
            //DeskMenuList deskMenu = srv.GetDeskList(MainWindow.Table); //מביא את כל השולחנות
            //listDish.ItemsSource    = deskMenu.FindAll(item => item.Desk.Id==MainWindow.Table.Id); //מציג את השולחן הספציפי

            listDish.ItemsSource = null; //force refresh
            listDish.ItemsSource = ordMList;

        }

        private void AllMeals_Checked(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)  //חזור
        {
            NavigationService.Navigate(new MainGuest());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)  //סיים הזמנה
        {
          double price=  srv.DeskOrder(this.tempMlst);
            totalPrice = price + totalPrice;
            this.PriceTxt.Content = "סה\"כ לתשלום : "+totalPrice;
            this.tempMlst.Clear();
           // srv.ChangeDeskStatus(MainWindow.Table, JS.טבח);
        }

        //private void CheckBox_Checked(object sender, RoutedEventArgs e)
        //{
        //    if (Gluten.IsChecked == true)
        //    {
        //        glutenUse();
        //    }


        //}

        //private void Gluten_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    pnl.Children.Clear();

        //    foreach (Menuu m in mlst)
        //    {
        //        DishUC uc = new DishUC(m);
        //        uc.Margin = new Thickness(10);
        //        uc.Selected += Uc_Selected;
        //        pnl.Children.Add(uc);
        //    }
        //}



        //private void firstMealChange(object sender, RoutedEventArgs e)
        //{
        //    if (this.firstMeal.IsChecked == true)
        //    {

        //    }
        //    else
        //    { }

        //}
    }
}



