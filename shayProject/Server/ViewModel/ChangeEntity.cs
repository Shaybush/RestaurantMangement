using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.OleDb;

namespace ViewModel
{
    //  public delegate string CreateSql(BaseEntity entity);
    public delegate void CreateSql(BaseEntity entity,OleDbCommand command);
    public class ChangeEntity
    {
        private BaseEntity entity;
        private CreateSql createSql;
        public ChangeEntity(CreateSql createSql, BaseEntity entity)
        {
            this.CreateSql = createSql;
            this.Entity = entity;
        }

        public BaseEntity Entity { get => entity; set => entity = value; }
        public CreateSql CreateSql { get => createSql; set => createSql = value; }
    }
}
