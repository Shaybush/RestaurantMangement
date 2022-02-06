using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [CollectionDataContract]
    public class DeskMenuList: List<DeskMenu>
    {
        public DeskMenuList() { } // default

        public DeskMenuList(IEnumerable<DeskMenu> list) : base(list) { }
        public DeskMenuList(IEnumerable<BaseEntity> list) : base(list.Cast<DeskMenu>().ToList()) { }
    }
}
