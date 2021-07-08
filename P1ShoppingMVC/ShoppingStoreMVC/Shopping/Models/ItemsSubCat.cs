using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Shopping.Models
{
    public partial class ItemsSubCat
    {
        public ItemsSubCat()
        {
            Inventories = new HashSet<Inventory>();
            Items = new HashSet<Item>();
        }
        [Key]
        public int SubCatId { get; set; }
        public int CatId { get; set; }
        public string SubCatName { get; set; }

        public virtual ItemsCat Cat { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
