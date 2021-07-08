using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDbContext.Models;

namespace ShopStore
{
    public class locationHistory
    {


        List<Cart> MyList = new List<Cart>();


        public locationHistory(List<Cart> cart, string UserName, string address, string city, string State, string zip, string storeName, String StoreStreet, string storecity, string storestate, string
            storezip, string storephone, float TotInvoice, int userPK)
        {
            Console.Clear();
            Console.WriteLine($"===============================================================================================================");
            Console.WriteLine($"[ Welcome {UserName} ]");
            Console.WriteLine($"===============================================================================================================", Console.ForegroundColor = ConsoleColor.White);

            Console.WriteLine("[ NUM ]  [   Order Number    ]   [ Order Date ]   [    Store Name & Address    ]       [   Total   ]      ");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();




            SHOPPING_DBContext context = new SHOPPING_DBContext();
            var OHistory = context.OrderNumbers.Where(s => s.UserPk == userPK).ToList();
            for (int i = 0; i <= OHistory.Count - 1; i++)
            {

                string a1 = OHistory[i].OrderNo.ToString("000000").PadRight(20);
                string b1 = OHistory[i].OrderDate.ToString("MM/dd/yyyy").PadRight(15);
                string c1 = OHistory[i].StoreBranchId.ToString().PadRight(18);
                string d1 = "";
                string e1 = "";
                //string f1 = "".ToString().PadRight(18);;
                string g1 = "";



                var BStoreN = context.StoreBranches.Where(s => s.StoreBranchId == OHistory[i].StoreBranchId).ToList();
                if (BStoreN.Count != 0)
                {
                    d1 = BStoreN[0].StoreCity.PadRight(15);
                    e1 = BStoreN[0].StoreState.PadRight(8);
                    //f1 = BStoreN[0].StoreNameId;

                }
                var StoreN = context.StoresNames.Where(s => s.StoreNameId == BStoreN[0].StoreNameId).ToList();
                if (StoreN.Count != 0)
                {
                    g1 = StoreN[0].StoreName.ToString().PadRight(18);
                }


                float Total = 0;
                var InvToal = context.Orders.Where(s => s.OrderNo == OHistory[i].OrderNo).ToList();
                if (InvToal.Count() != 0)
                {
                    for (int j = 0; j <= InvToal.Count() - 1; j++)
                    {
                        Total = Total + (InvToal[j].Qty * InvToal[j].UnitPrice);
                    }
                }
                string toto = Total.ToString("0.00");


                Console.WriteLine($"[ {i + 1} ]          {a1}{b1}{d1}{e1}{g1}{toto}");



            }
            int Choose = 0;
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"[ 0 ]===>   Go To Previous Menu  OR    Select The Invoice # To View ");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");

            while (!int.TryParse(Console.ReadLine(), out Choose) || !(Choose <= OHistory.Count && Choose >= 0))
            {
                Console.WriteLine("That was invalid. Enter a valid number");

            }
            if (Choose != 0)
            {
                Console.Clear();
                List<Cart> CartList = new List<Cart>();
                var InvToal = context.Orders.Where(s => s.OrderNo == OHistory[Choose - 1].OrderNo).ToList();
                float subtotal = 0;
                if (InvToal.Count() != 0)
                {

                    for (int j = 0; j <= InvToal.Count() - 1; j++)
                    {
                        var Item = context.Items.Where(s => s.ItemId == InvToal[j].ItemId).ToList();

                        CartList.Add(new Cart(InvToal[j].ItemId, (int)Item[0].SubCatId, InvToal[j].UnitPrice, InvToal[j].Qty,
                        OHistory[Choose - 1].StoreBranchId, userPK, Item[0].ItemName));
                        subtotal = subtotal + (InvToal[j].UnitPrice * InvToal[j].Qty);
                    }
                }

                var InvDet = context.Orders.Where(s => s.OrderNo == OHistory[Choose - 1].OrderNo).ToList();

                HistoryDetails MyCartList = new HistoryDetails(CartList, UserName, "", city, State, zip, storeName, StoreStreet, storecity, storestate,
                storezip, storephone, subtotal, userPK);
            }



        }


    }




}
