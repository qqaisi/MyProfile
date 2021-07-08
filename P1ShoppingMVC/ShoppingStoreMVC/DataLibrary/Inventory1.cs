using System;
using System.Collections.Generic;

#nullable disable

namespace DataLibrary
{
    public partial class Inventory1
    {
        public int ItemId { get; set; }
        public int StoreBranchId { get; set; }
        public int Qty { get; set; }
        public float UnitPrice { get; set; }
        public float UnitCost { get; set; }
        public int MinQty { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int SubCatId { get; set; }

        public virtual Item Item { get; set; }
        public virtual StoreBranch StoreBranch { get; set; }
        public virtual ItemsSubCat SubCat { get; set; }
    }
}
