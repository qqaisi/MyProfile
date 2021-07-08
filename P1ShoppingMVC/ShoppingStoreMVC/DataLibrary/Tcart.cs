using System;
using System.Collections.Generic;

#nullable disable

namespace DataLibrary
{
    public partial class Tcart
    {
        public int Itemid { get; set; }
        public double Unitprice { get; set; }
        public int Qty { get; set; }
        public int Minqty { get; set; }
        public string Itemname { get; set; }
        public int Userpk { get; set; }
        public double Subtot { get; set; }
        public double Total { get; set; }


    }
}
