﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderList : List<Order>
    {

        public OrderList() { } // default

        public OrderList(IEnumerable<Order> list) : base(list) { }
        public OrderList(IEnumerable<BaseEntity> list) : base(list.Cast<Order>().ToList()) { }

    }
}
