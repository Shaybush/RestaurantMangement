using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class OrderDB:BaseDB
    {
        static private OrderList orderList = null;
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Order order = entity as Order;
            order.Paid = (bool)reader["paid"];
            order.DeskMenu = new DeskMenu();
            order.Date = (DateTime)reader["date"];

            return order;
        }
        public OrderList SelectAll()
        {
            //command.CommandText = "SELECT *,PeopleTable.ID AS ID FROM StudentTable INNER JOIN StudentTable ON PeopleTable.ID=StudentTable.ID ";
            command.CommandText = "SELECT * FROM Order";
            orderList = new OrderList(Select());
            return orderList;
        }

        public Order SelectByID(int id)
        {
            command.CommandText = string.Format("SELECT *id FROM  Order WHERE   (id = 1)", id);
            List<BaseEntity> orderList = base.Select();
            if (orderList.Count == 1)
                return orderList[0] as Order;
            return null;
        }


       
    public override void Insert(BaseEntity entity)
    {
        Order order = entity as Order;
        if (order != null)
        {
            inserted.Add(new ChangeEntity(CreateInsertSQL, entity));
        }
    }



    public override void Update(BaseEntity entity)
    {
        Order order = entity as Order;
        if (order != null)
        {
            //insert.Add(new ChangeEntity(base.CreateUpdateSQL,entity));
            updated.Add(new ChangeEntity(CreateUpdateSQL, entity));

        }

    }
    public override void Delete(BaseEntity entity)
    {
        Order order = entity as Order;
        if (order != null)
        {
            //insert.Add(new ChangeEntity(base.CreateUpdateSQL,entity));
            deleted.Add(new ChangeEntity(CreateDeleteSQL, entity));

        }
    }
    protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
    {
        Order order = entity as Order;
        StringBuilder oledDB_builder = new StringBuilder();
        //       oledDB_builder.AppendFormat("INSERT INTO Order (Desk, MenuTbl, date) VALUES ('{0}', '{1}',#{2}#)",order.DeskMenu.Id , order.DeskMenu.Id, order.Date);
        oledDB_builder.AppendFormat("INSERT INTO Order (DeskMenu, paid, date) VALUES ('{0}', {1}, @date)", order.DeskMenu.Id, order.Paid, order.Date);
            cmd.Parameters.Add(new OleDbParameter("date", order.Date));
            //  return oledDB_builder.ToString();
            cmd.CommandText = oledDB_builder.ToString();
    }

    protected override void CreateDeleteSQL(BaseEntity entity, OleDbCommand cmd) //לעשות גם delete
    {

        Order order = entity as Order;
        StringBuilder oledDB_builder = new StringBuilder();
        oledDB_builder.AppendFormat("DELETE FROM Order WHERE ID={0}", order.Id);
        // return oledDB_builder.ToString();
        cmd.CommandText = oledDB_builder.ToString();

    }

    protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd) // וגם update
    {
        int x;
        Order order = entity as Order;
        StringBuilder oledDB_builder = new StringBuilder();
        oledDB_builder.AppendFormat("UPDATE  [Order] SET   DeskMenu = {0},@date, paid ={2}, id = {3}", order.DeskMenu.Id,order.Date,order.Paid,order.Id);
            cmd.Parameters.Add(new OleDbParameter("date", order.Date));
            //  return oledDB_builder.ToString();
            cmd.CommandText = oledDB_builder.ToString();
    }

    protected override BaseEntity newEntity()
    {
        return new Order() as BaseEntity;
    }
}
}
