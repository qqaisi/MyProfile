using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Shopping.BLL
{
    public class CartListClass 
    {

        private static int _item_id=0;
        private static float _UnitePrice =0;
        private static int _Qty =0;
        private static int _minQty =0;
        private static string _ItemName ="";

        public string ItemName
        {
            get
            {
                return _ItemName;
            }
            set
            {
                _ItemName = value;

            }
        }

        public float UnitePrice
        {
            get
            {
                return _UnitePrice;
            }
            set
            {
                _UnitePrice = value;

            }
        }


        public int item_id
        {
            get
            {
                return _item_id;
            }
            set
            {
                _item_id = value;

            }
        }

        public int minQty
        {
            get
            {
                return _minQty;
            }
            set
            {
                _minQty = value;

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






        static List<Cart> _list;

            
            static CartListClass()
            {
                // Allocate the list.
                _list = new List<Cart>();
            }
       
            public static void AddItem( Cart cart)
            {
                // Record this value in the list.
                _list.Add(cart);
            }

            public static int CountItems()
            {
            // Record this value in the list.
            return _list.Count();
            }


        //            public static void Display()
        //            {
        // Write out the results.
        //                foreach (var value in _list)
        //                {
        //                    Console.WriteLine(value);
        //                }
    }







}

