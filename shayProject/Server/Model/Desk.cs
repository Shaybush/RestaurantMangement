using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public class Desk:BaseEntity 
    {
        private int NumDesk; // מספר שולחן  
        private int size; // גודל שולחן 
        private JobStatus job; // מצב שולחן 
        public Desk() { }

        public int NumDesk1 { get => NumDesk; set => NumDesk = value; }
        public int Size { get => size; set => size = value; }
        public JobStatus Job { get => job; set => job = value; }
    }
}
