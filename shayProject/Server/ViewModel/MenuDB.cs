using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using Model;

namespace ViewModel
{
    public class MenuDB : BaseDB
    {
        static private MenuList menuList = null;
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Menuu menu = entity as Menuu;
            menu.Id = (int)reader["ID"];
            menu.FoodName = reader["FoodName"].ToString();
            menu.Price = reader["Price"].ToString();
            menu.GlutenFree = (bool)reader["GlutenFree"];
            menu.Information = reader["Information"].ToString();
            menu.Pic1 = reader["Pic"].ToString();
            int t = (int)reader["TypeDishes"];
            TypeDishesDB db = new TypeDishesDB();
            menu.Type = db.SelectByID(t);

            return menu;
        }
        public MenuList SelectAll()
        {
            //command.CommandText = "SELECT *,PeopleTable.ID AS ID FROM StudentTable INNER JOIN StudentTable ON PeopleTable.ID=StudentTable.ID ";
            command.CommandText = "SELECT * FROM MenuTbl";
            menuList = new  MenuList (Select());
            return menuList;
        }
        public MenuList SelectByName(string foodName)
        {
            command.CommandText = string.Format("SELECT  *FROM  MenuTbl  WHERE  (foodName = '1')", foodName);
            List<Menuu> menuList = base.Select().Cast<Menuu>().ToList();
            return new MenuList(menuList);
        }
        public Menuu SelectByID(int id)
        {
            command.CommandText = string.Format("SELECT *id FROM  MenuTbl WHERE   (id = 1)", id);
            List<BaseEntity> menuList = base.Select();
            if (menuList.Count == 1)
                return menuList[0] as Menuu;
            return null;
        }
        //public MenuList SelectByGluten()



        public override void Insert(BaseEntity entity)
        {
            Menuu menu = entity as Menuu;
            if (menu != null)
            {
                //insert.Add(new ChangeEntity(base.CreateInsertSQL,entity));
                inserted.Add(new ChangeEntity(CreateInsertSQL, entity));

            }
        }

        public override void Update(BaseEntity entity)
        {
            Menuu menu = entity as Menuu;
            if (menu != null)
            {
                //insert.Add(new ChangeEntity(base.CreateUpdateSQL,entity));
                updated.Add(new ChangeEntity(CreateUpdateSQL, entity));

            }

        }
        public override void Delete(BaseEntity entity)
        {
            Menuu menu = entity as Menuu;
            if (menu != null)
            {
                //insert.Add(new ChangeEntity(base.CreateUpdateSQL,entity));
                deleted.Add(new ChangeEntity(CreateDeleteSQL, entity));

            }

        }









        protected override void CreateDeleteSQL(BaseEntity entity, OleDbCommand cmd) //לעשות גם delete
        {

            Menuu menu = entity as Menuu;
            StringBuilder oledDB_builder = new StringBuilder();
            oledDB_builder.AppendFormat("DELETE FROM MenuTbl WHERE ID={0}", menu.Id);
            //return oledDB_builder.ToString();
            cmd.CommandText = oledDB_builder.ToString();

        }



        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Menuu menu = entity as Menuu;
            StringBuilder oledDB_builder = new StringBuilder();
            oledDB_builder.AppendFormat("INSERT INTO MenuTbl  (foodName, price, glutenFree, information, pic, TypeDishes)" +
                "VALUES('{0}','{1}', {2}, '{3}','{4}',{5})", menu.FoodName, menu.Price, menu.GlutenFree, menu.Information, menu.Pic1, menu.Type.Id);
            //return oledDB_builder.ToString();
            cmd.CommandText= oledDB_builder.ToString();
        }



        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd) // וגם update
        {
            int x;
            Menuu menu = entity as Menuu;
            StringBuilder oledDB_builder = new StringBuilder();
            if(menu.GlutenFree == false)
            {
                x = 0;
            }
            else
            {
                x = 1;
            }
            oledDB_builder.AppendFormat("UPDATE MenuTbl SET  foodName ='{0}', price ={1}, glutenFree ='{2}', information ='{3}', pic ='{4}', TypeDishes = {5} WHERE ID={6}", menu.FoodName , menu.Price , x , menu.Information , menu .Pic1 , menu .Type .Id , menu.Id);
            //return oledDB_builder.ToString();
            cmd.CommandText = oledDB_builder.ToString();
        }

        protected override BaseEntity newEntity()
        {
            return new Menuu() as BaseEntity;
        }
    }
}
