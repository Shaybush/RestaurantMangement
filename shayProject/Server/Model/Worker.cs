using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Worker : BaseEntity
    {
      //  private int Id;

        private String name;
        private bool Gender;
        private String UserName;
        private String Password;
        private Position pos;

        public bool Gender1 { get => Gender; set => Gender = value; }
        public string UserName1 { get => UserName; set => UserName = value; }
        public string Password1 { get => Password; set => Password = value; }
        public string Name { get => name; set => name = value; }
   //     public int Id1 { get => Id; set => Id = value; }
        public Position Pos
        {
            get => pos; set => pos = value;

        }
    }
}
