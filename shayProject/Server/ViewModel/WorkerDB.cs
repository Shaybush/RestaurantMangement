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
    public class WorkerDB: BaseDB
    {

     

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Worker worker = entity as Worker;

            worker.Id = (int)reader["ID"];

            worker.Name = reader["Name"].ToString();

            worker. Gender1=(bool)reader["Gender"];

            worker. UserName1=reader["UserName"].ToString();

            worker. Password1= reader["Password"].ToString();

            int p = (int)reader["Position"];
            PositionDB db = new PositionDB();
            worker.Pos = db.SelectByID(p);

      

            return worker;
        }

        public WorkerList SelectAll()
        {
            command.CommandText = "SELECT *   FROM Worker";

            WorkerList workerList = new WorkerList(base.Select());
            return workerList;
        }
        public WorkerList SelectByName(string name)
        {
            command.CommandText = string.Format("SELECT * FROM Worker WHERE(Name = '1')",name);
            List<Worker> workerList = base.Select().Cast<Worker>().ToList();
            return new WorkerList(workerList);
        }
        public Worker SelectByID(int id)
        {
            command.CommandText = string.Format("SELECT* ID FROM Worker WHERE(ID = 0)", id);
            List<BaseEntity> workerList = base.Select();
            if (workerList.Count == 1)
                return workerList[0] as Worker;
            return null;
        }

        public Worker Login(string name,string pas)
        {
            command.CommandText = string.Format("SELECT *  FROM Worker WHERE(UserName='{0}' and [Password]= '{1}')", name,pas);
            List<Worker> workerList = base.Select().Cast<Worker>().ToList();
            if (workerList.Count == 1)
                return workerList[0] as Worker;
            return null;
        }

        public override void Insert(BaseEntity entity)
        {
            Worker  worker = entity as Worker;
            if (worker != null)
            {
                inserted.Add(new ChangeEntity(CreateInsertSQL, entity));

            }
        }

        public override void Update(BaseEntity entity)
        {
            Worker worker = entity as Worker;
            if (worker != null)
            {
                updated.Add(new ChangeEntity(CreateUpdateSQL, entity));

            }

        }
        public override void Delete(BaseEntity entity)
        {
            Worker worker = entity as Worker;
            if (worker != null)
            {
                deleted.Add(new ChangeEntity(CreateDeleteSQL, entity));

            }

        }

        protected override BaseEntity newEntity()

        { return new Worker() as BaseEntity; }


        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Worker worker = entity as Worker;
            StringBuilder oledDB_builder = new StringBuilder();
            oledDB_builder.AppendFormat("INSERT INTO Worker(Name, Gender, UserName, [Password],[Position] )" +
                "VALUES('{0}',{1}, '{2}', '{3}',{4})", worker.Name, worker.Gender1, worker.UserName1, worker.Password1,worker.Pos.Id);
            //return oledDB_builder.ToString();
            cmd.CommandText = oledDB_builder.ToString();
        }

        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Worker worker = entity as Worker;
            StringBuilder oledDB_builder = new StringBuilder();
            oledDB_builder.AppendFormat("UPDATE Worker SET Name = '{0}', Gender = {1}, UserName = '{2}', [Password] = '{3}', [Position] = {4}  WHERE ID={5}", worker.Name,worker.Gender1 , worker.UserName1, worker.Password1, worker.Pos.Id, worker.Id);
            //return oledDB_builder.ToString();
            cmd.CommandText = oledDB_builder.ToString();
        }


        protected override void CreateDeleteSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Worker worker = entity as Worker;
            StringBuilder oledDB_builder = new StringBuilder();
            oledDB_builder.AppendFormat("DELETE FROM Worker WHERE ID={0}", worker.Id );
            //return oledDB_builder.ToString();
            cmd.CommandText = oledDB_builder.ToString();
        }
    }
}
