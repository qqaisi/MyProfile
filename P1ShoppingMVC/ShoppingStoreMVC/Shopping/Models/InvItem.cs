using System;
using System.Collections.Generic;

#nullable disable

namespace Shopping.Models
{
    public partial class InvItem 
    {
        public int StoreBranchId { get; set; }
        public int Qty { get; set; }
        public float UnitPrice { get; set; }
        public float UnitCost { get; set; }
        public int MinQty { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int ItemId { get; set; }
        public int SubCatId { get; set; }
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }
        

    }
}
