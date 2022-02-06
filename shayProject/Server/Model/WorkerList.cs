using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [CollectionDataContract]

    public class WorkerList : List<Worker>
    {
       
        public WorkerList() { } // default
       
        public WorkerList(IEnumerable<Worker> list) : base(list) { }
      
        public WorkerList(IEnumerable<BaseEntity> list) : base(list.Cast<Worker>().ToList()) { }
    }
}
