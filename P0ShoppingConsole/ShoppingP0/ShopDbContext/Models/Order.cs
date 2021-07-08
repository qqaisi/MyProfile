using System;
using System.Collections.Generic;

#nullable disable

namespace ShopDbContext.Models
{
    public partial class Order
    {
        //public int OrderNo { get; set; }
        //public int ItemId { get; set; }
        //public int Qty { get; set; }
        //public float UnitPrice { get; set; }

        public virtual Item Item { get; set; }
        public virtual OrderNumber OrderNoNavigation { get; set; }

        private int _OrderNo;
        private int _ItemId;
        private int _Qty;
        private float _UnitPrice;


        public float UnitPrice
        {
            get
            {
                return _UnitPrice;
            }
            set
            {
                _UnitPrice = value;

            }
        }

        public int Qty
        {
            get
            {
                return _Qty;
            }
            set
            {
                _Qty = value;

            }
        }


        public int ItemId
        {
            get
            {
                return _ItemId;
            }
            set
            {
                _ItemId = value;

            }
        }

        public int OrderNo
        {
            get
            {
                return _OrderNo;
            }
            set
            {
                _OrderNo = value;

            }
        }




    }
}
