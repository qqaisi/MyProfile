using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDbContext.Models;

namespace ShopStore
{
    public class InvAvailable
    {



        private int _item_id;
        private int _StoreBranchID;
        private int _SubCatId;
        private int _Qty;
        private float _UnitPrice;
        //private float _UnitCost;
        //private int _MinQty;
        private DateTime _ExpirationDate;
        private string _ItemName;

        public int SubCatId
        {
            get
            {
                return _SubCatId;
            }
            set
            {
                _SubCatId = value;
            }
        }



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

        public int StoreBranchID
        {
            get
            {
                return _StoreBranchID;
            }
            set
            {
                _StoreBranchID = value;
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


        public float UnitePrice
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

        public DateTime ExpirationDate
        {
            get
            {
                return _ExpirationDate;
            }
            set
            {
                _ExpirationDate = value;
            }
        }



        public InvAvailable(int S_C_ID,int B_S_ID,List<Cart> Cart_List,string UserName,string addressm, string city, string State, string zip ,string storeName, String StoreStreet, string storecity,string storestate, string
            storezip,string storephone, float TotInvoice,int userPK)
        {
            SHOPPING_DBContext context = new SHOPPING_DBContext();
            
            var invCTX = context.Inventories.Where(s => s.StoreBranchId == B_S_ID && s.SubCatId == S_C_ID).ToList();
            Console.WriteLine("[ NUM ]       [   ITEM NAME    ]   [    QTY   ]   [ UNIT PRICE ]   [ Exp. Date ]      [  DESCREIPTION  ]");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            
            for (int i = 0; i <= invCTX.Count - 1; i++)
            {
                var ItemCTX = context.Items.Where(s => s.ItemId == invCTX[i].ItemId).ToList();
                string q = invCTX[i].Qty.ToString().PadRight(15);
                string w = invCTX[i].UnitPrice.ToString().PadRight(17);
                string r = invCTX[0].ExpirationDate.Date.ToString("MM/dd/yyyy").PadRight(20);
                string y = ItemCTX[0].ItemDesc.PadRight(30);
                Console.WriteLine($"[ {i+1} ]          {ItemCTX[0].ItemName.PadRight(21)}{q}{w}{r}{y}");
                
            }

            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"[ 0 ]===>   Go To Previous Menu  OR    [99] To Review Your Cart     OR    [100] To View History");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
            
            Console.Write("Choose the Item & QTY :");
            //string valid = Console.ReadLine();

            int Choose;
            while (!int.TryParse(Console.ReadLine(), out Choose) || !((Choose <= invCTX.Count && Choose >= 0) || Choose == 99 || Choose == 100 ))
            {
                Console.WriteLine("That was invalid. Enter a valid number");

            }
            if (Choose != 0)
            {
                if (Choose != 99 && Choose!=100)
                {
                    this.item_id = (int)invCTX[Choose - 1].ItemId;
                    var ItemCTX = context.Items.Where(s => s.ItemId == this.item_id).ToList();
                    this.ItemName = ItemCTX[0].ItemName;
                    this.Qty = invCTX[Choose - 1].Qty;
                    this.UnitePrice = invCTX[Choose - 1].UnitPrice;
                    this.ExpirationDate = invCTX[Choose - 1].ExpirationDate;
                    this.StoreBranchID = invCTX[Choose - 1].StoreBranchId;
                    this.ItemName = ItemCTX[0].ItemName;
                    this.SubCatId = (int)ItemCTX[0].SubCatId;
                    Console.WriteLine($"[ { this.ItemName } ] - [ {this.UnitePrice}]", Console.ForegroundColor = ConsoleColor.Green);
                    Console.Write("", Console.ForegroundColor = ConsoleColor.White);

                    var invCompare = context.Inventories.Where(s => s.StoreBranchId != B_S_ID && s.ItemId == this.item_id).ToList();
                    for (int i = 0; i <= invCompare.Count - 1; i++)
                    {
                        var Branch = context.StoreBranches.Where(s => s.StoreBranchId == invCompare[i].StoreBranchId).ToList();
                        var Store = context.StoresNames.Where(s => s.StoreNameId == Branch[0].StoreBranchId).ToList();
                        Console.WriteLine($"[ { Store[0].StoreName.PadLeft(10) } ] - [ {invCompare[0].UnitPrice}]", Console.ForegroundColor = ConsoleColor.Red);

                    }

                    Console.Write("", Console.ForegroundColor = ConsoleColor.White);
                    int TQTY = 0;
                    Console.WriteLine($"Please Enter The Quantity , And the Maximum Order is {this.Qty}");
                    while (!int.TryParse(Console.ReadLine(), out TQTY) || !(TQTY <= this.Qty && TQTY >= 0))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("                             ");
                    }
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.WriteLine("                             ");


                    float Total = TQTY * this.UnitePrice;
                    this.Qty = TQTY;
                    Console.Write($"Your Total will Be ----", Console.ForegroundColor = ConsoleColor.White);
                    Console.WriteLine($"[$ { Total }] ", Console.ForegroundColor = ConsoleColor.Green);
                    Console.WriteLine("Press Enter To Continue", Console.ForegroundColor = ConsoleColor.White);
                    Console.ReadLine();
                }
                else
                {
                    if (Choose == 99)
                    {
                        Console.Clear();
                        MyCart MyCartList = new MyCart(Cart_List, UserName, addressm, city, State, zip, storeName, StoreStreet, storecity, storestate,
                        storezip, storephone, TotInvoice, userPK);
                    }
                    else
                    {
                        Console.Clear();
                        CustomerHistory  MyCustomerHistory = new CustomerHistory(Cart_List, UserName, addressm, city, State, zip, storeName, StoreStreet, storecity, storestate,
                        storezip, storephone, TotInvoice, userPK);

                    }


                }
                
                
            }   


        }




    }
}