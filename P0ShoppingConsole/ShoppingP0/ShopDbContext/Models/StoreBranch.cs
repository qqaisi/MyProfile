using System;
using System.Collections.Generic;

#nullable disable

namespace ShopDbContext.Models
{
    public partial class StoreBranch
    {
        public StoreBranch()
        {
            Inventories = new HashSet<Inventory>();
            OrderNumbers = new HashSet<OrderNumber>();
        }

        public int StoreBranchId { get; set; }
        public int StoreNameId { get; set; }
        public string StoreStreet { get; set; }
        public string StoreCity { get; set; }
        public string StoreState { get; set; }
        public string StoreZipcode { get; set; }
        public string StorePhone { get; set; }

        public virtual StoresName StoreName { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<OrderNumber> OrderNumbers { get; set; }
    }
}
