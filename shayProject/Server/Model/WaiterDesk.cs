using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WaiterDesk
    {
        Desk desk;  // שולחן 
        Worker work; // עובד 

        public Desk Desk { get => desk; set => desk = value; }
        public Worker Work { get => work; set => work = value; }
    }
}
