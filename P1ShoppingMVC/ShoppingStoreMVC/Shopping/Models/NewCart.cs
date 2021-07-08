using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Models
{
    public class NewCart
    {


        public int ItemId { get; set; }
        public float UnitPrice { get; set; }
        public int Qty { get; set; }
        public int MinQty { get; set; }
        public string ItemName { get; set; }



    }
}
