using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order:BaseEntity
    {
        private DeskMenu deskMenu;
        private DateTime date;
        private Boolean paid;

        public Order() { }

        public Order(DeskMenu dm,DateTime dt)
        {
            this.deskMenu = dm;
            this.date = dt;
            this.paid = false;
        }

        public DeskMenu DeskMenu { get => deskMenu; set => deskMenu = value; }
        public DateTime Date { get => date; set => date = value; }
        public bool Paid { get => paid; set => paid = value; }
    }
}
