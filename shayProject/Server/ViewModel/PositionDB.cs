using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class PositionDB:BaseDB
    {
        static private PositionList list = null;
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Position position = entity as Position;
            position.Id = (int)reader["ID"];
            position.Job = reader["Job"].ToString();
            return position;
        }
        public PositionList SelectAll()
        {
            command.CommandText = "SELECT * FROM [Position]";
            list = new PositionList(Select());
            return list;
        }
        public Position SelectByID(int id)
        {
            if (list == null)
            {
                PositionDB db = new PositionDB();
                list = db.SelectAll();
            }
            Position job = list.Find(item => item.Id == id);
            return job;
        }
        protected override BaseEntity newEntity()
        { return new Position() as BaseEntity; }


        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateDeleteSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }
    }
}
