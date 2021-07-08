using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDbContext.Models;

namespace ShopStore
{
    public class HistoryDetails
    {


        List<Cart> MyList = new List<Cart>();


        public HistoryDetails(List<Cart> cart, string UserName, string address, string city, string State, string zip, string storeName, String StoreStreet, string storecity, string storestate, string
            storezip, string storephone, float TotInvoice, int userPK)
        {
            Console.Clear();
            Console.WriteLine($"===============================================================================================================");
            Console.Write($"[ Welcome {UserName} ] >> [  {storeName} ] >>  [ {StoreStreet} - {storestate} ] >>  [ {storezip} - {storephone} ] ");
            Console.WriteLine($"[ Cart Total ${TotInvoice.ToString("0.00")}  ]", Console.ForegroundColor = ConsoleColor.Green);
            Console.WriteLine($"===============================================================================================================", Console.ForegroundColor = ConsoleColor.White);

            Console.WriteLine("[ NUM ]       [            ITEM NAME             ]   [    QTY   ]   [ UNIT PRICE ]   [ Total ]      ");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();






            for (int i = 0; i <= cart.Count - 1; i++)
            {

                string q = cart[i].Cart_Name.ToString().PadRight(40);
                string w = cart[i].Cart_Qty.ToString().PadRight(15);
                string r = cart[i].Cart_UnitPrice.ToString("0.00").PadRight(18);
                string y = ((int)cart[i].Cart_Qty * (float)cart[i].Cart_UnitPrice).ToString("0.00");
                Console.WriteLine($"[ {i + 1} ]          {q}{w}{r}{y}");

            }
            Console.WriteLine($"===============================================================================================================");
            Console.Write($"Ship to [ {UserName} ] >> [  {address} ] >>  [ {city} - {State} ] >>  [ {zip} ] ");
            Console.WriteLine($"[ Cart Total ${TotInvoice.ToString("0.00")}  ]", Console.ForegroundColor = ConsoleColor.Green);
            Console.WriteLine($"===============================================================================================================", Console.ForegroundColor = ConsoleColor.White);

            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"[ 0 ]===>   Go To Previous Menu  OR    [1] To Save The Order ");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");

            int Choose;
            while (!int.TryParse(Console.ReadLine(), out Choose) || !(Choose <= 1 && Choose >= 0))
            {
                Console.WriteLine("That was invalid. Enter a valid number");

            }
            if (Choose == 1)
            {

                using (var context = new SHOPPING_DBContext())
                {



                    var newOrderNo = new OrderNumber();


                    //newOrderNo.OrderNo = OrdernoValue.OrderNo + 1;
                    newOrderNo.UserPk = userPK;
                    newOrderNo.StoreBranchId = cart[0].Cart_BranchId;
                    //OrderNo.OrderDate = DateTime.Parse(DateTime.FromOADate);
                    context.OrderNumbers.Add(newOrderNo);
                    context.SaveChanges();
                    var OrdernoValue = context.OrderNumbers.OrderByDescending(a => a.OrderNo).FirstOrDefault();

                    //Console.WriteLine(OrdernoValue.OrderNo);
                    //Console.ReadLine();
                    //var OrdernoValue = context.OrderNumbers.ToList();
                    //newOrderNo.OrderNo = OrdernoValue.Count() + 1;

                    for (int i = 0; i <= cart.Count - 1; i++)
                    {
                        var invCompare = context.Inventories.SingleOrDefault(s => s.StoreBranchId == cart[i].Cart_BranchId && s.ItemId == cart[i].Cart_ItemId);
                        if (invCompare.Qty >= cart[i].Cart_Qty)
                        {
                            var OrderList = new Order();
                            OrderList.OrderNo = OrdernoValue.OrderNo;
                            OrderList.ItemId = cart[i].Cart_ItemId;
                            OrderList.Qty = cart[i].Cart_Qty;
                            OrderList.UnitPrice = (float)cart[i].Cart_UnitPrice;
                            context.Orders.Add(OrderList);

                            //InventoryUpdate.Qty = InventoryUpdate.Qty - cart[i].Cart_Qty;
                            invCompare.Qty = invCompare.Qty - cart[i].Cart_Qty;
                            context.Inventories.Update(invCompare);

                        }
                    }

                    context.SaveChanges();

                    WelcomePage.InvTotal = 0;

                    cart.Clear();

                }

            }
            else
            {


            }


        }


    }




}
