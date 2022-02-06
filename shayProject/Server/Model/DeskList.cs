using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [CollectionDataContract]
    public class DeskList:List<Desk>
    {
        public DeskList() { } // default

        public DeskList(IEnumerable<Desk> list) : base(list) { }
        public DeskList(IEnumerable<BaseEntity> list) : base(list.Cast<Desk>().ToList()) { }
    }
}
