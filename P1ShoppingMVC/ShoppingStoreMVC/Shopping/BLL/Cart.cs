using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.BLL
{
    public class Cart
    {


        //static List<Cart> CartList = new List<Cart>();
        private static int _Cart_ItemId;
        private int _Cart_SubCatId;
        private float _Cart_UnitPrice;
        private int _Cart_Qty;
        private int _Cart_BranchId;
        private int _Cart_UsePk;
        private string _Cart_Name;
        private float _InvTotal;



        public string Cart_Name
        {
            get
            {
                return _Cart_Name;
            }
            set
            {
                _Cart_Name = value;

            }
        }
        public int Cart_UsePk
        {
            get
            {
                return _Cart_UsePk;
            }
            set
            {
                if (value != 0)
                {
                    _Cart_UsePk = value;
                }
            }
        }
        public int Cart_BranchId
        {
            get
            {
                return _Cart_BranchId;
            }
            set
            {
                if (value != 0)
                {
                    _Cart_BranchId = value;
                }
            }
        }

        public int Cart_Qty
        {
            get
            {
                return _Cart_Qty;
            }
            set
            {
                if (value != 0)
                {
                    _Cart_Qty = value;
                }
            }
        }

        public float InvTotal
        {
            get
            {
                return _InvTotal;
            }
            set
            {
                if (value != 0)
                {
                    _InvTotal = value;
                }
            }
        }
        public float Cart_UnitPrice
        {
            get
            {
                return _Cart_UnitPrice;
            }
            set
            {
                if (value != 0)
                {
                    _Cart_UnitPrice = value;
                }
            }
        }
        public int Cart_ItemId
        {
            get
            {
                return _Cart_ItemId;
            }
            set
            {
                if (value != 0)
                {
                    _Cart_ItemId = value;
                }
            }
        }


        public int Cart_SubCatId
        {
            get
            {
                return _Cart_SubCatId;
            }
            set
            {
                if (value != 0)
                {
                    _Cart_SubCatId = value;
                }
            }
        }



        public Cart(int Cart_itemid, int Cart_subcatid, float Cart_unitprice, int Cart_qty, int Cart_branchid, int Cart_userpk, String Cart_name)
        {
            this.Cart_ItemId = Cart_itemid;
            this.Cart_SubCatId = Cart_subcatid;
            this.Cart_UnitPrice = Cart_unitprice;
            this.Cart_Qty = Cart_qty;
            this.Cart_BranchId = Cart_branchid;
            this.Cart_ItemId = Cart_itemid;
            this.Cart_Name = Cart_name;

        }





    }
}
