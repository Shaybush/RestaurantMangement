using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [CollectionDataContract]
    public class JobStatusList : List<JobStatus>
    {
        
        public JobStatusList() { } // default

        public JobStatusList(IEnumerable<JobStatus> list) : base(list) { }
        public JobStatusList(IEnumerable<BaseEntity> list) : base(list.Cast<JobStatus>().ToList()) { }
    }
}
