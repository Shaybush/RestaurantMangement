using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [CollectionDataContract]
    public class MenuList: List<Menuu>
    {
        public MenuList() { } // default

        public MenuList(IEnumerable<Menuu> list) : base(list) { }
        public MenuList(IEnumerable<BaseEntity> list) : base(list.Cast<Menuu>().ToList()) { }
    }
}
