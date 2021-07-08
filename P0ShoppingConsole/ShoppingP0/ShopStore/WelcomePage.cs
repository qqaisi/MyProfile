using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDbContext.Models;


namespace ShopStore
{
    public class WelcomePage
    {
        public static float InvTotal=0;
        public int UserID { get; set; }
        public static void WelcomeMsg()
        {
           // Console.WriteLine("Welcome To Our Store Chain");
            string UserID = "";
            string UserPwd = "";
            
            //instanitae the Log in Object
            LogingIn LogIn = new LogingIn(UserID, UserPwd);
            
            if (LogIn.UserId != "")
            {
                int BranchSelect = 0;
                do
                {
                    List<Cart> CartList = new List<Cart>();
                    AddToCart TotalInvoice = new AddToCart();
                    Console.Clear();
                    Console.WriteLine($"===============================================================================================================");
                    Console.Write($"[ Welcome {LogIn.UserId} ] >> ");
                    Console.WriteLine($"[ Cart Total ${InvTotal.ToString("0.00")}  ]", Console.ForegroundColor = ConsoleColor.Green);
                    Console.WriteLine($"===============================================================================================================", Console.ForegroundColor = ConsoleColor.White);
                    Console.WriteLine();
                    SelectStore SelectS = new SelectStore();
                    if (SelectS.StoreID == 0)
                    {
                        UserID = "";
                        UserPwd = "";
                        SelectS.StoreID = 0;
                        LogingIn Login1 = new LogingIn(UserID, UserPwd);
                        LogIn = Login1;
                    }
                    else
                    {
                        int DepSelected = 0;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine($"===============================================================================================================");
                            Console.Write($"[ Welcome {LogIn.UserId} ] >> [  {SelectS.StoreName} ] >> ");
                            Console.WriteLine($"[ Cart Total ${InvTotal.ToString("0.00")}  ]", Console.ForegroundColor = ConsoleColor.Green);
                            Console.WriteLine($"===============================================================================================================", Console.ForegroundColor = ConsoleColor.White);
                            Console.WriteLine();
                            SelectBranch SelectB = new SelectBranch(SelectS.StoreID);

                            BranchSelect = SelectB.StoreBranchId;
                            if (SelectB.StoreBranchId == 0)
                            {
                                //SelectS.Equals(null);
                                //SelectB.Equals(null);
                                //BranchSelect = 0;
                                //DepSelected = 0;
                            }
                            else
                            {
                                int SubCatSelected = 0;
                                do
                                {
                                    Console.Clear();
                                    Console.WriteLine($"===============================================================================================================");
                                    Console.Write($"[ Welcome {LogIn.UserId} ] >> [  {SelectS.StoreName} ] >>  [ {SelectB.StoreCity} - {SelectB.StoreState} ] >> ");
                                    Console.WriteLine($"[ Cart Total ${InvTotal.ToString("0.00")}  ]", Console.ForegroundColor = ConsoleColor.Green);
                                    Console.WriteLine($"===============================================================================================================", Console.ForegroundColor = ConsoleColor.White);
                                    Console.WriteLine();
                                    Department DepSelect = new Department();
                                    DepSelected = DepSelect.CatId;

                                    if (DepSelect.CatId == 0)
                                    {
                                        if (InvTotal != 0)
                                        {
                                            Console.WriteLine("Because You Added Items Into Your Cart You Can Not Change The Branch...!");
                                            Console.ReadLine();

                                        }
                                        //SelectB.Equals(null);
                                        //DepSelect.Equals(null);
                                        //DepSelected = 0;
                                        //BranchSelect = 1;
                                    }
                                    else
                                    {
                                        int ItemSelected = 0;
                                        do
                                        {
                                            

                                            Console.Clear();
                                            Console.WriteLine($"===============================================================================================================");
                                            Console.Write($"[ Welcome {LogIn.UserId} ] >> [  {SelectS.StoreName} ] >>  [ {SelectB.StoreCity} - {SelectB.StoreState} ] >> ");
                                            Console.WriteLine($"[ Cart Total ${InvTotal.ToString("0.00")}  ]", Console.ForegroundColor = ConsoleColor.Green);
                                            Console.WriteLine($"===============================================================================================================", Console.ForegroundColor = ConsoleColor.White);

                                            Console.WriteLine();
                                            Console.WriteLine($"[ {DepSelect.CatName} ] ");
                                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
                                            Console.WriteLine();
                                            SubCat SubCateS = new SubCat(DepSelect.CatId);
                                            SubCatSelected = SubCateS.SubCatId;
                                            // Here to Select The section 
                                            if (SubCateS.SubCatId == 0)
                                            {
                                                

                                                //SelectB.Equals(null);
                                                //DepSelect.Equals(null);
                                                //DepSelected = 0;
                                                //BranchSelect = 1;
                                            }
                                            else
                                            {

                                                do
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine($"===============================================================================================================");
                                                    Console.Write($"[ Welcome {LogIn.UserId} ] >> [  {SelectS.StoreName} ] >>  [ {SelectB.StoreCity} - {SelectB.StoreState} ] >> ");
                                                    Console.WriteLine($"[ Cart Total ${InvTotal.ToString("0.00")}  ]", Console.ForegroundColor = ConsoleColor.Green);
                                                    Console.WriteLine($"===============================================================================================================", Console.ForegroundColor = ConsoleColor.White);

                                                    Console.WriteLine();
                                                    Console.WriteLine($"[ {DepSelect.CatName} ] - [ {SubCateS.SubCatName} ]",Console.ForegroundColor = ConsoleColor.Yellow);
                                                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------",Console.ForegroundColor = ConsoleColor.White);

                                                    InvAvailable Inv = new InvAvailable(SubCateS.SubCatId, BranchSelect,CartList,LogIn.UserId,LogIn.Ustreet,LogIn.Ucity,LogIn.Ustate,LogIn.Uzip, SelectS.StoreName, SelectB.StoreStreet, SelectB.StoreCity, SelectB.StoreState, SelectB.StoreZipCode, SelectB.StorePhone, InvTotal, LogIn.UserPK);
                                                    ItemSelected = Inv.item_id;
                                                    if (Inv.item_id == 0)
                                                    {
                                                    }
                                                    else
                                                    {

                                                        bool found = false;
                                                        int itemPostion = 0;
                                                        for (int j=0; j<=CartList.Count()-1; j++)
                                                        {
                                                            if (Inv.item_id == CartList[j].Cart_ItemId)
                                                            {
                                                                found = true;
                                                                itemPostion = j;
                                                            }
                                                        }
                                                        if (found == true)
                                                        {
                                                            CartList[itemPostion].Cart_Qty = CartList[itemPostion].Cart_Qty + Inv.Qty;
                                                        }
                                                        else {
                                                            CartList.Add(new Cart(Inv.item_id, Inv.SubCatId, Inv.UnitePrice, Inv.Qty,
                                                            Inv.StoreBranchID, LogIn.UserPK, Inv.ItemName));
                                                        }

                                                        
                                                        InvTotal = TotalInvoice.AddToCartTotal(InvTotal, Inv.UnitePrice, Inv.Qty);
                                                         

                                                        //Console.ReadLine();
                                                    }
                                                }
                                                while (ItemSelected != 0 );

                                            }

                                        } 
                                        while ((ItemSelected != 0 || SubCatSelected != 0) && InvTotal == 0);
                                    }
                                     
                                }
                                while (SubCatSelected != 0 || DepSelected != 0  );

                            }
                        }
                        while (DepSelected != 0 || BranchSelect != 0);
                    }                   
                }
                while (BranchSelect == 0);
                
            }
        }

    }
}

