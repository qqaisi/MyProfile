using System;
using System.Collections.Generic;

#nullable disable

namespace DataLibrary
{
    public partial class Order
    {
        public int OrderNo { get; set; }
        public int ItemId { get; set; }
        public int Qty { get; set; }
        public float UnitPrice { get; set; }

        public virtual Item Item { get; set; }
        public virtual OrderNumber OrderNoNavigation { get; set; }
    }
}
