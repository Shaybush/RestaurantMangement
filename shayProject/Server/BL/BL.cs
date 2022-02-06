using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ViewModel;

namespace BL
{
  public static   class BL
    {
        static DeskList deskList ;
        static JobStatusList status;
        static DeskMenuList menuList = new DeskMenuList();

        static BL() // static constractor
        {
            DeskDB db = new DeskDB();
            deskList = db.SelectAll();   // ge90;4t all Desks
            JobStatusDB sdb = new JobStatusDB();
            status = sdb.SelectAll();
        }

        public static void Add(Menuu menu, Desk desk) // מוסיף מנה לשולחן
        {
            DeskMenu deskMenu = new DeskMenu(menu,desk);

            //menu.status = Status.Cheff;
            //menu.desk = desk;
            menuList.Add(deskMenu);
        }

        //public static DeskMenuList GetCheffList() // מביא את כל המנות שה postion שלהם הוא של שף
        //{
        //    return new DeskMenuList( menuList.FindAll (item => item.Desk.Job.Id==3).ToList()); // i don't have in DeskMenu the action Status i have that action in Menu. 
        //}

        

         public static DeskMenuList GetDeskMenuList(JS js) // מביא את כל המנות שה postion שלהם הוא של שף
        {
            return new DeskMenuList(menuList.FindAll(item => item.Stat == js).ToList()); // i don't have in DeskMenu the action Status i have that action in Menu. 
        }


        public static Boolean ClearDesk(Desk d) // בודק אם השולחן תפוס או פנוי
        {
            if(d.Job.Id==1)
            {
                return true;
            }
            return false;
        }

        public static Desk GetFreeDesk(int size)
        {
            List<Desk> lst = deskList.FindAll(item => item.Job.Id == 1 && item.Size >= size).ToList().   // get all free desk
                OrderBy(item => item.Size).ToList();  // orderd by size
            Desk desk= lst.FirstOrDefault();  // return the 1st OR null
            if (desk != null)
                ChangeDeskStatus(desk, JS.תפוס);

            return desk;
        }

        public static DeskList GetAllDesks()
        {
            return deskList;

        }



        public static DeskMenuList GetDeskList(Desk desk) // ההזמנה של השולחן
        {
            return new DeskMenuList( menuList.FindAll(item => item.Desk.Id == desk.Id));
        }

        public static void ChangeDeskStatus(Desk desk, JS ss) // 
        {
           Desk dd = deskList.Find(item => item.Id == desk.Id);
            dd.Job = status.Find(item => item.Id == (int)ss);
        }


        public static double GetDeskBill(Desk desk)   // עושה חשבון לשולחן
        {
             List<DeskMenu> list = GetDeskList(desk);
            int total = 0;
            foreach (DeskMenu m in list)
            {
                total += int.Parse (m.Menu.Price) ;  
            }
            return total;
        }

        public static double DeskOrder(DeskMenuList list) //מנות חדשות
        {
            double x = 0;
            foreach (DeskMenu dm in list)
            {
              //  dm.Stat = JS.טבח;
                menuList.Add(dm);
                x = x + dm.Amount * int.Parse(dm.Menu.Price);
            }
            return x;
        }
        public static int ChangeStatus(DeskMenu deskMenu, JS js)
        {
            DeskMenu dm = menuList.Find(item => item.Desk.Id == deskMenu.Desk.Id && item.Menu.Id == deskMenu.Menu.Id);
            if (dm == null)
                return -1; //error
            else
            {
                dm.Stat = js;
                return dm.Desk.Id;
            }
        }

    }
}
