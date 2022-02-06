using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Model
{
    public enum JS
    {
        פנוי = 1,
        מלצר = 2,
        טבח = 3,
        מוכן = 7,
        תפוס = 8
    }
    public  class JobStatus:BaseEntity 
    {
        

        private String Situation;
        public string Situation1{ get => Situation; set => Situation = value; }
        //1 
        //2
        //3
        //4
        //5
        //6

        private Color color;
        public Color Color { get => color; set => color = value; }

    }
}
