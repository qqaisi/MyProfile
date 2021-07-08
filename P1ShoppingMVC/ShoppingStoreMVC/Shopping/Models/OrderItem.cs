using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Models
{
    public class OrderItem
    {
        public int itemid { get; set; }
        public int ItemName { get; set; }
        public int Qty { get; set; }
        public float UnitPrice { get; set; }
        public int Details { get; set; }
        public int OrderedQty { get; set; }

    }
}
