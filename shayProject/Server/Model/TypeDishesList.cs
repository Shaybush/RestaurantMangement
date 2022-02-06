using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [CollectionDataContract]
    public class TypeDishesList:List<TypeDishes>
    {
        public TypeDishesList() { }
        public TypeDishesList(IEnumerable<TypeDishes> list) : base(list) { }
        public TypeDishesList(IEnumerable<BaseEntity> list) : base(list.Cast<TypeDishes>().ToList()) { }


    }
}
/*public class PositionList : List<Position>
{
    public PositionList() { } // default

    public PositionList(IEnumerable<Position> list) : base(list) { }
    public PositionList(IEnumerable<BaseEntity> list) : base(list.Cast<Position>().ToList()) { }
    */

