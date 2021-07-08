using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Shopping.Models
{
    public partial class OrderNumber
    {
        public OrderNumber()
        {
            Orders = new HashSet<Order>();
        }
        [Key]
        public int OrderNo { get; set; }
        public int UserPk { get; set; }
        public DateTime OrderDate { get; set; }
        public int StoreBranchId { get; set; }
        public  BLL.Variables Info { get; set; }

        public virtual StoreBranch StoreBranch { get; set; }
        public virtual User UserPkNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
