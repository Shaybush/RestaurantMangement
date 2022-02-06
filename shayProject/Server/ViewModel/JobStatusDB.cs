using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

using System.Windows.Media;

namespace ViewModel
{
    public class JobStatusDB : BaseDB
    {
        static private JobStatusList  list = null;
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            JobStatus  job = entity as JobStatus ;
            job.Id= (int)reader["ID"];
            job.Situation1 = reader["Situation"].ToString();
            job.Color =  (Color)ColorConverter.ConvertFromString(reader["color"].ToString());
            return job;
        }
        public JobStatusList  SelectAll()
        {
            command.CommandText = "SELECT * FROM [JobStatus]";
            list = new JobStatusList (Select());
            return list;
        }
        public JobStatus SelectByID(int id)
        {
            if (list == null)
            {
                JobStatusDB db = new JobStatusDB();
                list = db.SelectAll();
            }
            JobStatus  t = list.Find(item => item.Id == id);
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
            return new JobStatus() as BaseEntity;
        }
    }
}
