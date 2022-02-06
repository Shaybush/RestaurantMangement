using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class DeskDB:BaseDB
    {

        static private DeskList  deskList = null;
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Desk desk = entity as Desk;
            desk.Id = (int)reader["ID"];
            desk.NumDesk1 =(int) reader["NumDesk"];
            desk.Size = (int)reader["size"];
            int j = (int)reader["JobStatus"];
            JobStatusDB db = new JobStatusDB();
            desk.Job = db.SelectByID(j);

            return desk;
        }
        public DeskList SelectAll()
        {
            //command.CommandText = "SELECT *,PeopleTable.ID AS ID FROM StudentTable INNER JOIN StudentTable ON PeopleTable.ID=StudentTable.ID ";
            command.CommandText = "SELECT * FROM Desk";
            deskList = new DeskList(Select());
            return deskList;
        }
        public DeskList SelectByName(string numDesk1)
        {
            command.CommandText = string.Format("SELECT  *FROM  Desk  WHERE  (NumDesk = '1')", numDesk1);
            List<Desk> deskList = base.Select().Cast<Desk>().ToList();
            return new DeskList(deskList);
        }
        public Desk SelectByID(int id)
        {
            command.CommandText = string.Format("SELECT *id FROM  Desk WHERE   (id = 1)", id);
            List<BaseEntity> deskList = base.Select();
            if (deskList.Count == 1)
                return deskList[0] as Desk;
            return null;
        }

        public void ChangeStatus(Desk desk)
        {
            desk.Job.Id = 2;
        }
        //public MenuList SelectByGluten()



        public override void Insert(BaseEntity entity)
        {
            Desk desk = entity as Desk;
            if (desk != null)
            {
                //insert.Add(new ChangeEntity(base.CreateInsertSQL,entity));
                inserted.Add(new ChangeEntity(CreateInsertSQL, entity));

            }
        }

        public override void Update(BaseEntity entity)
        {
            Desk desk = entity as Desk;
            if (desk != null)
            {
                //insert.Add(new ChangeEntity(base.CreateUpdateSQL,entity));
                updated.Add(new ChangeEntity(CreateUpdateSQL, entity));

            }

        }
        public override void Delete(BaseEntity entity)
        {
            Desk desk = entity as Desk;
            if (desk != null)
            {
                //insert.Add(new ChangeEntity(base.CreateUpdateSQL,entity));
                deleted.Add(new ChangeEntity(CreateDeleteSQL, entity));

            }

        }









        protected override void CreateDeleteSQL(BaseEntity entity, OleDbCommand cmd) //לעשות גם delete
        {

            Desk desk = entity as Desk;
            StringBuilder oledDB_builder = new StringBuilder();
            oledDB_builder.AppendFormat("DELETE FROM Desk WHERE ID={0}", desk.Id);
            //return oledDB_builder.ToString();
            command.CommandText = oledDB_builder.ToString();

        }



        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Desk desk = entity as Desk;
            StringBuilder oledDB_builder = new StringBuilder();
            oledDB_builder.AppendFormat("INSERT INTO Desk(NumDesk, [size], JobStatus) "+"VALUES('{0}', '{1}',{ 2})", desk.NumDesk1,desk.Size,desk.Job.Id);
            //return oledDB_builder.ToString();
            command.CommandText = oledDB_builder.ToString();
        }



        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd) // וגם update
        {
            Desk desk = entity as Desk;
            StringBuilder oledDB_builder = new StringBuilder();
            oledDB_builder.AppendFormat("UPDATE Desk SET NumDesk = '{0}', [size] = '{1}', JobStatus = {2}, ID = {3}", desk.NumDesk1, desk.Size,desk.Job.Id, desk.Id);
            //  return oledDB_builder.ToString();
            cmd.CommandText = oledDB_builder.ToString();
        }

        protected override BaseEntity newEntity()
        {
            return new Desk() as BaseEntity;
        }

    }
}
