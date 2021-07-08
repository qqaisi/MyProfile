using System;
using System.Collections.Generic;

#nullable disable

namespace DataLibrary
{
    public partial class OrderNumber
    {
        public OrderNumber()
        {
            Orders = new HashSet<Order>();
        }

        public int OrderNo { get; set; }
        public int UserPk { get; set; }
        public DateTime OrderDate { get; set; }
        public int StoreBranchId { get; set; }

        public virtual StoreBranch StoreBranch { get; set; }
        public virtual User UserPkNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
