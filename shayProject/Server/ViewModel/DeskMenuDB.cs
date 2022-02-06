using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class DeskMenuDB:BaseDB
    {
        static private DeskMenuList  deskMenuList = null;
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            DeskMenu deskMenu = entity as DeskMenu;
            deskMenu.Desk = new Desk();
            deskMenu.Menu = new Menuu();
            //int d = (int)reader["MenuTbl"];
            //MenuDB mb = new MenuDB();
            //desk.Menu = mb.SelectByID(d);



            return deskMenu;
        }
        public DeskMenuList  SelectAll()
        {
            //command.CommandText = "SELECT *,PeopleTable.ID AS ID FROM StudentTable INNER JOIN StudentTable ON PeopleTable.ID=StudentTable.ID ";
            command.CommandText = "SELECT * FROM DeskMenu";
            deskMenuList = new DeskMenuList(Select());
            return deskMenuList;
        }
        public DeskMenuList SelectAllMT()
        {
            command.CommandText = "SELECT * FROM DeskMenu";
            deskMenuList = new DeskMenuList(Select());
            return deskMenuList;
        }
        public DeskMenuList SelectByName(string size) // מוצא שולחן עפ"י הגודל שלו
        {
            command.CommandText = string.Format("SELECT  *FROM  DeskMenu  WHERE  (size = '1')", size);
            List<DeskMenu> deskList = base.Select().Cast<DeskMenu>().ToList();
            return new DeskMenuList(deskList);
        }
        public DeskMenu SelectByID(int id)
        {
            command.CommandText = string.Format("SELECT *id FROM  DeskMenu WHERE   (id = 1)", id);
            List<BaseEntity> deskList = base.Select();
            if (deskList.Count == 1)
                return deskList[0] as DeskMenu;
            return null;
        }


        public override void Insert(BaseEntity entity)
        {
            DeskMenu desk = entity as DeskMenu;
            if (desk != null)
            {
                //insert.Add(new ChangeEntity(base.CreateInsertSQL,entity));
                inserted.Add(new ChangeEntity(CreateInsertSQL, entity));

            }
        }

        public override void Update(BaseEntity entity)
        {
            DeskMenu  desk = entity as DeskMenu;
            if (desk != null)
            {
                //insert.Add(new ChangeEntity(base.CreateUpdateSQL,entity));
                updated.Add(new ChangeEntity(CreateUpdateSQL, entity));

            }

        }
        public override void Delete(BaseEntity entity)
        {
            Desk menu = entity as Desk;
            if (menu != null)
            {
                //insert.Add(new ChangeEntity(base.CreateUpdateSQL,entity));
                deleted.Add(new ChangeEntity(CreateDeleteSQL, entity));

            }
        }

                    protected override void CreateDeleteSQL(BaseEntity entity, OleDbCommand cmd) //לעשות גם delete
        {

            DeskMenu desk = entity as DeskMenu;
            StringBuilder oledDB_builder = new StringBuilder();
            oledDB_builder.AppendFormat("DELETE FROM DeskMenu WHERE ID={0}", desk.Id);
          //  return oledDB_builder.ToString();
          cmd.CommandText = oledDB_builder.ToString();

        }



        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            DeskMenu desk = entity as DeskMenu;
            StringBuilder oledDB_builder = new StringBuilder();
            oledDB_builder.AppendFormat("INSERT INTO DeskMenu (Desk, MenuTbl)" + "VALUES ('{0}', '{1}')");
            //  return oledDB_builder.ToString();
            cmd.CommandText = oledDB_builder.ToString();
        }



        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd) // וגם update
        {
            int x;
            DeskMenu desk = entity as DeskMenu;
            StringBuilder oledDB_builder = new StringBuilder();
            oledDB_builder.AppendFormat("UPDATE DeskMenu SET  Desk = {1}, MenuTbl = {2} WHERE ID = {3}" ,desk.Desk.Id, desk.Menu.Id ,desk.Id);
            //    return oledDB_builder.ToString();
            cmd.CommandText = oledDB_builder.ToString();
        }

        protected override BaseEntity newEntity()
        {
            return new DeskMenu() as BaseEntity;
        }




    }




    }

