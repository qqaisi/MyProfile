using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RLL;
using DataLibrary;




namespace Shopping.BLL
{


    public class UserProccessor
    {

        public Variables VarList = new Variables();
        public static int CreateUser(string userId, string userPwd, string street, string city, string state, string zipCode, string email)
        {


            Models.User NewUser = new Models.User
            {
                Userid = userId,
                User_Pwd = userPwd,
                Ustreet = street,
                Ucity = city,
                Ustate = state,
                Uzip = zipCode,
                Email = email,
                StoreBranchId=Variables._branchIdC
                
                

            };
            string sql = @"insert into users (UserId,User_Pwd,Ustreet,Ucity,Ustate,Uzip,Email,StoreBranchId) 
                        values(@Userid,@User_Pwd,@UStreet,@Ucity,@Ustate,@Uzip,@Email,@StoreBranchId)";

            return RLL.DataAccess.SaveData(sql, NewUser);



        }





       public static List<DataLibrary.OrderNumber> LoadHistroy()
        {


            
            List<OrderNumber> tcart = RLL.DataAccess.AllDbContextOrderListByUser();



            return tcart;
        }

        public static List<DataLibrary.OrderNumber> LoadHistroy(int id)
        {



            List<OrderNumber> tcart = RLL.DataAccess.AllDbContextOrderListByUser(id);



            return tcart;
        }

        //================================by location orders


        public static List<DataLibrary.OrderNumber> LoadHistroyByLocation(int branchid)
        {
            List<OrderNumber> tcart = RLL.DataAccess.AllDbContextOrderListByLocation(branchid);
            return tcart;
        }


        public static List<DataLibrary.Tcart> LoadCart()
        {


            List<DataLibrary.Tcart> tcart = RLL.DataAccess.AllDbContextTotalCart(Variables._userPKC);


            return tcart;
        }

        public static int  DeleteFromCart(int id)
        {

            DataLibrary.Tcart MyCart = new DataLibrary.Tcart
            {
                Userpk = Variables._userPKC,
                Itemid = id
            };
            string sql = @"delete from  Tcart where itemid=@Itemid and userpk=@Userpk";
            RLL.DataAccess.SaveData(sql, MyCart);


            
            var tcart = RLL.DataAccess.AllDbContextTotalCart(Variables._userPKC);

            double tot = 0;
            for (int i = 0; i < tcart.Count(); i++)
            {
                tot = tot + (tcart[i].Minqty * tcart[i].Unitprice);
            }
            MyCart.Total = Math.Round(tot, 2);
            

            string sql1 = @"update TCart set Total=@Total where userpk=@Userpk ";
            return RLL.DataAccess.SaveData(sql1, MyCart);


            
        }

        public static int AddToCart(int itemid, double unitprice, int qty, int minqty,string itemname)
        {
            int CurrentQty = 0;
            List<DataLibrary.Tcart> tcart = RLL.DataAccess.AllDbContextTotalCart( Variables._userPKC);



            double tot = 0;
            for (int i = 0; i < tcart.Count(); i++)
            {
                tot = tot + (tcart[i].Minqty * tcart[i].Unitprice);
            }
            Variables._TotalC = Math.Round(tot,2);
            
            if (tcart.Count == 0)
            {
            }


            DataLibrary.Tcart MyCart = new DataLibrary.Tcart
            {
                Itemid = itemid,
                Unitprice = unitprice,
                Qty = qty,
                Minqty = minqty,
                Itemname = itemname,
                Userpk = Variables._userPKC,
                Subtot = Math.Round( minqty * unitprice,2),
                Total= Math.Round(Variables._TotalC + (minqty * unitprice),2)


            };

            List<DataLibrary.Tcart> tcartUpdate = RLL.DataAccess.AllDbContextTcart(itemid,Variables._userPKC);
            if (tcartUpdate.Count == 0)
            {

                
                string sql = @"insert into TCart (itemid,unitprice,qty,minqty,itemname,userpk,Subtot,Total) 
                        values(@Itemid,@Unitprice,@Qty,@Minqty,@Itemname,@Userpk,@Subtot,@Total)";
                return RLL.DataAccess.SaveData(sql, MyCart);


            }
            else
            {

                if (tcartUpdate[0].Minqty + minqty <= qty)
                {
                    CurrentQty = minqty + tcartUpdate[0].Minqty;
                }
                else
                {
                    CurrentQty = MyCart.Minqty;
                }
                MyCart.Minqty = CurrentQty;
                MyCart.Subtot = Math.Round(MyCart.Minqty*MyCart.Unitprice,2);
                MyCart.Total = Math.Round(CurrentQty + minqty*MyCart.Unitprice,2);

                string sql = @"update TCart set minqty = @Minqty, Subtot=@Subtot, Total=@Total where itemid=@Itemid and userpk=@Userpk ";
                return RLL.DataAccess.SaveData(sql, MyCart);

            }






        }











        //==============================Confirm The Cart=============================


        public static int ConfirmCart()
        {
            
            List<DataLibrary.Tcart> tcart = RLL.DataAccess.AllDbContextTotalCart(Variables._userPKC);
            double tot = 0;
            for (int i = 0; i < tcart.Count(); i++)
            {
                tot = tot + (tcart[i].Minqty * tcart[i].Unitprice);
            }
            Variables._TotalC = Math.Round(tot, 2);






            using (var context = new SHOPPING_DBContext())
            {



                var newOrderNo = new OrderNumber();


                //newOrderNo.OrderNo = OrdernoValue.OrderNo + 1;
                newOrderNo.UserPk = Variables._userPKC;
                newOrderNo.StoreBranchId = Variables._branchIdC;
                newOrderNo.OrderDate = DateTime.Today;
                //OrderNo.OrderDate = DateTime.Parse(DateTime.FromOADate);
                context.OrderNumbers.Add(newOrderNo);
                context.SaveChanges();
                var OrdernoValue = context.OrderNumbers.OrderByDescending(a => a.OrderNo).FirstOrDefault();
                for (int i = 0; i <= tcart.Count - 1; i++)
                {
                    var invCompare = context.Inventories.SingleOrDefault(s => s.StoreBranchId == Variables._branchIdC && s.ItemId == tcart[i].Itemid);
                    if (invCompare.Qty >= tcart[i].Minqty)
                    {
                        var OrderList = new Order();
                        OrderList.OrderNo = OrdernoValue.OrderNo;
                        OrderList.ItemId = tcart[i].Itemid;
                        OrderList.Qty = tcart[i].Minqty;
                        OrderList.UnitPrice = (float)tcart[i].Unitprice;
                        context.Orders.Add(OrderList);

                        //InventoryUpdate.Qty = InventoryUpdate.Qty - cart[i].Cart_Qty;
                        invCompare.Qty = invCompare.Qty - tcart[i].Minqty;
                        context.Inventories.Update(invCompare);

                    }
                }

                context.SaveChanges();

                DataLibrary.Tcart MyCart = new DataLibrary.Tcart
                {
                    Userpk = Variables._userPKC,
                    
                };
                string sql = @"delete from  Tcart where  userpk=@Userpk";
                RLL.DataAccess.SaveData(sql, MyCart);




            }



            return 1;




        }




        //==================================End of confirm the cart=======================











        public static Models.User LoadUser( string userid, string userpwd)
        {

            
            var LoggedUser = RLL.DataAccess.AllDbContext(userid, userpwd);
            if (LoggedUser.Count!=0)
            {
                List<Cart> CartList = new List<Cart>();

                Variables._UserIdC = LoggedUser[0].Userid ;
                Variables._StreetC = LoggedUser[0].Ustreet;
                Variables._CityC = LoggedUser[0].Ucity;
                Variables._StateC = LoggedUser[0].Ustate;
                Variables._ZipC = LoggedUser[0].Uzip;
                Variables._branchIdC = LoggedUser[0].StoreBranchId;


                Models.User NewUser = new Models.User
                {
                    UserPk = LoggedUser[0].UserPk,
                    Userid = LoggedUser[0].Userid,
                    User_Pwd = LoggedUser[0].User_Pwd,
                    Ustreet = LoggedUser[0].Ustreet,
                    Ucity = LoggedUser[0].Ucity,
                    Ustate = LoggedUser[0].Ustate,
                    Uzip = LoggedUser[0].Uzip,
                    Email = LoggedUser[0].Email,
                    StoreBranchId = LoggedUser[0].StoreBranchId
                

            };
                return NewUser;
            }
            return null;
            
            
        }


        public static List<DataLibrary.StoresName> LoadStoresID(int id)
        {

            List<DataLibrary.StoresName> StoresList = RLL.DataAccess.AllDbContextStoreId(id);

            return StoresList;
        }

        public static List<DataLibrary.StoresName> LoadStores()
        {

            List<DataLibrary.StoresName> StoresList = RLL.DataAccess.AllDbContext();
            
            return StoresList;
        }
        public static List<DataLibrary.StoreBranch> LoadBranches(int storenameid)
        {
            List<DataLibrary.StoreBranch> BranchesList = RLL.DataAccess.AllDbContext(storenameid);

            
            
            return BranchesList;
        }


        public static List<DataLibrary.StoreBranch> LoadBranchesLogIn(int storeBranchid)
        {
            List<DataLibrary.StoreBranch> BranchesList = RLL.DataAccess.AllDbContextLogInBranch(storeBranchid);



            return BranchesList;
        }


        //        
        //===============================search by customer ============================
        public static List<DataLibrary.User> LoadAllCustomer()
        {

            List<DataLibrary.User> CatList = RLL.DataAccess.AllDbContextSearchByCustomer();

            return CatList;
        }



        public static List<DataLibrary.ItemsCat> LoadCats()
        {

            List<DataLibrary.ItemsCat> CatList = RLL.DataAccess.AllDbContextCat();
            
            return CatList;
        }

        public static List<DataLibrary.ItemsSubCat> LoadSubCat(int catid)
        {

            List<DataLibrary.ItemsSubCat> SubCatList = RLL.DataAccess.AllDbContextCat(catid);
            
            
            return SubCatList;
        }



        

        public static IEnumerable<OrderDetails> AllDbContextLoadOrders(int orderno)
        {

            
            IEnumerable<OrderDetails> FinalOrder = RLL.DataAccess.AllDbContextLoadHistory(orderno);


            return FinalOrder;
        }


        public static IEnumerable<InvListM> LoadInvItems(int subcatid)
        {

            IEnumerable<InvListM> FinalInv = RLL.DataAccess.AllDbContextInv(subcatid);

            return FinalInv;
        }


















    }
}

