using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Shopping.Models
{
    public partial class Item
    {
        public Item()
        {
            Inventories = new HashSet<Inventory>();
            Orders = new HashSet<Order>();
        }
        [Key]
        public int ItemId { get; set; }
        public int SubCatId { get; set; }
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }

        public virtual ItemsSubCat SubCat { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
