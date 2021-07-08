using System;
using System.Collections.Generic;

#nullable disable

namespace ShopDbContext.Models
{
    public partial class Item
    {
        public Item()
        {
            Inventories = new HashSet<Inventory>();
            Orders = new HashSet<Order>();
        }

        public int ItemId { get; set; }
        public int? SubCatId { get; set; }
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }

        public virtual ItemsSubCat SubCat { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
