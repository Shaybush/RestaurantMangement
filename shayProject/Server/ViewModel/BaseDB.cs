 //using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System;

namespace ViewModel
{
    public abstract class BaseDB
    {
        private static string connectionString; //= @" Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\Users\User1\Desktop\shayProject\shayProject/Server\Host\ViewModel\פרוייקט 2017.accdb'; Persist Security Info=True";
        protected OleDbConnection connection;
        protected OleDbCommand command;
        protected OleDbDataReader reader;

        protected abstract BaseEntity newEntity();
        protected abstract BaseEntity CreateModel(BaseEntity entity);

        protected List<ChangeEntity> inserted = new List<ChangeEntity>();
        protected List<ChangeEntity> deleted = new List<ChangeEntity>();
        protected List<ChangeEntity> updated = new List<ChangeEntity>();

        protected abstract void CreateInsertSQL(BaseEntity entity, OleDbCommand comand);
        protected abstract void CreateUpdateSQL(BaseEntity entity, OleDbCommand comand);
        protected abstract void CreateDeleteSQL(BaseEntity entity, OleDbCommand comand);


        public BaseDB()
        {
            if (connectionString == null)
            {
             connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = "+DBPath ()+@"\פרוייקט 2017.accdb; Persist Security Info=True";
            }

            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();

        }

        private  string DBPath()
        {

            string s1 = "";
          
            //  string s = Environment.CurrentDirectory;  // שרץ exe-מקבל את כתובת ה
            String[] arguments = Environment.GetCommandLineArgs();
            string s;
            if (arguments.Length == 1) // direct execution
            { s = arguments[0]; }
            else  // service execution
            {
                s = arguments[1];
                s = s.Replace("/service:", "");  // remove /service: from the begining of the command line
            }
            string[] ss = s.Split('\\');   // פירוק המחרוזת למערך (ע"פ / שמפריד

            int x = ss.Length - 4;  //הורדתי 3 תיקיות מהסוף
            ss[x] = "ViewModel";   // ....שיניתי את התיקיה האחרונה ל
            Array.Resize(ref ss, x + 1);  // תיקון של אורך המערך, לאורך העכשווי

            s1 = String.Join("\\", ss);  // חיבור מחדש של המערך - עם / מפריד

            return s1;
        }

        public virtual void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = this.newEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity));
            }
        }
        public virtual void Delete(BaseEntity entity)
        {
            BaseEntity reqEntity = this.newEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                deleted.Add(new ChangeEntity(this.CreateDeleteSQL, entity));
            }
        }
        public virtual void Update(BaseEntity entity)
        {
            BaseEntity reqEntity = this.newEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
            }
        }

        protected List<BaseEntity> Select()
        {
            List<BaseEntity> list = new List<BaseEntity>();
            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BaseEntity entity = newEntity();
                    list.Add(CreateModel(entity));
                }
            }
            catch (Exception e) { }
            finally
            {
                if (reader != null) reader.Close();
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return list;
        }
        public  int SaveChanges()
        {
            int record_affected = 0;
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = this.connection;
                this.connection.Open();
                foreach (var item in inserted)
                {
                    //    command.CommandText = item.CreateSql(item.Entity);
                    cmd.Parameters.Clear();
                     item.CreateSql(item.Entity,cmd);
                    record_affected += cmd.ExecuteNonQuery();

                    cmd.CommandText = "Select @@Identity";
                    item.Entity.Id = (int)cmd.ExecuteScalar();
                }
                inserted.Clear();
                foreach (var item in updated)
                {
                    // command.CommandText = item.CreateSql(item.Entity);
                    cmd.Parameters.Clear();
                    item.CreateSql(item.Entity, cmd);
                    record_affected += cmd.ExecuteNonQuery();
                }
                updated.Clear();
                foreach (var item in deleted)
                {
                    //command.CommandText = CreateDeleteSQL(item.Entity);\
                    cmd.Parameters.Clear();
                    item.CreateSql(item.Entity, cmd);
                    record_affected += cmd.ExecuteNonQuery();
                }
                deleted.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error is:" + e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return record_affected;
        }
    }
}
