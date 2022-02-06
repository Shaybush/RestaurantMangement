using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Menuu:BaseEntity 
    {
        private String foodName;
        private String price;
        private bool glutenFree;
        private String information;
        private String Pic;
        private TypeDishes type;

        public string FoodName { get => foodName; set => foodName = value; }
        public string Price { get => price; set => price = value; }
        public bool GlutenFree { get => glutenFree; set => glutenFree = value; }
        public string Information { get => information; set => information = value; }
        public string Pic1 { get => Pic; set => Pic = value; }
        public TypeDishes Type
        {
            get => type; set => type = value;
        }
        //1
        //2
        //3
        //4
        //5
        //6
    }
}
