using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Shopping.Models
{
    public partial class ItemsCat
    {
        public ItemsCat()
        {
            ItemsSubCats = new HashSet<ItemsSubCat>();
        }
        [Key]
        public int CatId { get; set; }
        public string CatName { get; set; }

        public virtual ICollection<ItemsSubCat> ItemsSubCats { get; set; }
    }
}
