using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

     public class DeskMenu:BaseEntity
    {
        private Menuu menu; // תפריט 
        private Desk desk; // שולחן 
        private int amount; // כמות
        private JS stat; // מצב המנה
        
        //private int Count;
        public DeskMenu() { }

        public DeskMenu(Menuu menu, Desk desk)
        {
            this.menu = menu;
            this.desk = desk;
            this.desk.Job.Id = 3;
        }

        public Menuu Menu { get => menu; set => menu = value; }
        public Desk Desk { get => desk; set => desk = value; }
        public int Amount { get => amount; set => amount = value; }
        public JS Stat { get => stat; set => stat = value; }
    }
}
