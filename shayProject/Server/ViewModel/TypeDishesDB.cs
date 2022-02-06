using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class TypeDishesDB : BaseDB
    {
        static private TypeDishesList list = null;
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            TypeDishes type = entity as TypeDishes;
            type.Id = (int)reader["ID"];
            type.Ty  = reader["Type"].ToString();
            return type;
        }
        public TypeDishesList SelectAll()
        {
            command.CommandText = "SELECT * FROM [TypeDishes]";
            list = new TypeDishesList(Select());
            return list;
        }
        public TypeDishes SelectByID(int id)
        {
            if (list == null)
            {
                TypeDishesDB db = new TypeDishesDB();
                list = db.SelectAll();
            }
            TypeDishes t = list.Find(item => item.Id == id);
            return t;
        }

        protected override void CreateDeleteSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override BaseEntity newEntity()
        {
            return new TypeDishes () as BaseEntity; 
        }
    }
}