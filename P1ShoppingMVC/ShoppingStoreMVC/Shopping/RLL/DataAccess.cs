using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataLibrary;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using BLL;

namespace Shopping.RLL
{
    public static class DataAccess
    {

        public static string GetConnectionString(string connectionName = "RTM-GDR")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }
        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=SHOPPING_DB;Trusted_Connection=True;"))

                return cnn.Query<T>(sql).ToList();
        }
        
        
        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=SHOPPING_DB;Trusted_Connection=True;"))
                return cnn.Execute(sql, data);
            //Console.WriteLine(sql);
            //Console.ReadLine();
        }
        
        
        //EF dbContext method
        public static List<User> AllDbContext(string userid, string userpwd)
        {
            SHOPPING_DBContext context = new SHOPPING_DBContext();
            List<User> DBUser = context.Users.Where(s => s.Userid.ToLower() == userid.ToLower() && s.User_Pwd.ToLower() == userpwd.ToLower()).ToList();
            if (DBUser.Count != 0)
                return DBUser;
            else
                return DBUser;
        }

        public static List<StoresName> AllDbContext()
        {
            SHOPPING_DBContext context = new SHOPPING_DBContext();
            var DBStores = context.StoresNames.ToList();

            if (DBStores.Count != 0)
                return DBStores;
            else
                return DBStores;
        }




        public static List<Tcart> AllDbContextTotalCart(int userpk)
        {
            SHOPPING_DBContext context = new SHOPPING_DBContext();
            var TCART = context.Tcarts.Where(s => s.Userpk == userpk).ToList();

            if (TCART.Count != 0)
                return TCART;
            else
                return TCART;
        }


        public static List<OrderNumber> AllDbContextOrderListByUser()
        {



            SHOPPING_DBContext sd = new SHOPPING_DBContext();
            var DBOrders = sd.OrderNumbers.Where(s => s.UserPk == BLL.Variables._userPKC).ToList();
            //context.Entry(TCART).State = EntityState.Deleted;
            //context.SaveChanges();
            if (DBOrders.Count != 0)
                return DBOrders;
            else
                return DBOrders;
        }
        public static List<OrderNumber> AllDbContextOrderListByUser(int id)
        {



            SHOPPING_DBContext sd = new SHOPPING_DBContext();
            var DBOrders = sd.OrderNumbers.Where(s => s.UserPk == id).ToList();
            //context.Entry(TCART).State = EntityState.Deleted;
            //context.SaveChanges();
            if (DBOrders.Count != 0)
                return DBOrders;
            else
                return DBOrders;
        }
        //=====================================end Display Orders based on location=====================================================
        public static List<OrderNumber> AllDbContextOrderListByLocation(int branchid)
        {



            SHOPPING_DBContext sd = new SHOPPING_DBContext();
            var DBOrders = sd.OrderNumbers.Where(s => s.StoreBranchId == branchid).ToList();

            //context.Entry(TCART).State = EntityState.Deleted;
            //context.SaveChanges();
            if (DBOrders.Count != 0)
                return DBOrders;
            else
                return DBOrders;
        }




        public static int AllDbContextTcartDelete(int itemid, int userpk)
        {
            SHOPPING_DBContext context = new SHOPPING_DBContext();
            var TCART = context.Tcarts.Where(s => s.Itemid == itemid && s.Userpk == userpk).ToList();
            if (TCART.Count != 0)
            { 
                context.Entry(TCART[0]).State = EntityState.Deleted;
                context.SaveChanges();
            }
            return 1;
        }
        
        
        public static List<Tcart> AllDbContextTcart(int itemid,int userpk)
        {
            SHOPPING_DBContext context = new SHOPPING_DBContext();
            var TCART = context.Tcarts.Where(s => s.Itemid == itemid && s.Userpk==userpk).ToList();
            //context.Entry(TCART).State = EntityState.Deleted;
            //context.SaveChanges();
            if (TCART.Count != 0)
                return TCART;
            else
                return TCART;
        }




        public static List<StoresName> AllDbContextStoreId(int id)
        {
            SHOPPING_DBContext context = new SHOPPING_DBContext();
            var DBStores = context.StoresNames.Where(s => s.StoreNameId == id).ToList();

            if (DBStores.Count != 0)
                return DBStores;
            else
                return DBStores;
        }

        public static List<StoreBranch> AllDbContext(int storenameid)
        {
            SHOPPING_DBContext context = new SHOPPING_DBContext();
            var DBBranches = context.StoreBranches.Where(s => s.StoreNameId == storenameid).ToList();

            if (DBBranches.Count != 0)
                return DBBranches;
            else
                return DBBranches;
        }

        public static List<StoreBranch> AllDbContextLogInBranch(int id)
        {
            SHOPPING_DBContext context = new SHOPPING_DBContext();
            var DBBranches = context.StoreBranches.Where(s => s.StoreBranchId == id).ToList();

            if (DBBranches.Count != 0)
                return DBBranches;
            else
                return DBBranches;
        }

        //======================search by customer======================
        public static List<User> AllDbContextSearchByCustomer()
        {
            SHOPPING_DBContext context = new SHOPPING_DBContext();
            var DBCats = context.Users.ToList();

            if (DBCats.Count != 0)
                return DBCats;
            else
                return DBCats;
        }

        public static List<ItemsCat> AllDbContextCat()
        {
            SHOPPING_DBContext context = new SHOPPING_DBContext();
            var DBCats = context.ItemsCats.ToList();

            if (DBCats.Count != 0)
                return DBCats;
            else
                return DBCats;
        }

        public static List<ItemsSubCat> AllDbContextCat(int catid)
        {
            SHOPPING_DBContext context = new SHOPPING_DBContext();
            var DBSubCat = context.ItemsSubCats.Where(s => s.CatId == catid).ToList();

            if (DBSubCat.Count != 0)
                return DBSubCat;
            else
                return DBSubCat;
        }

        public static IEnumerable<InvListM> AllDbContextInv(int catid)
        {
            SHOPPING_DBContext sd = new SHOPPING_DBContext();

            List<Item> ITMname = sd.Items.ToList();
            List<Inventory> TInv = sd.Inventories.ToList();

            var MutilpleTBL = from Inv in TInv
                              join Itm in ITMname on Inv.ItemId equals Itm.ItemId into table1
                              where Inv.SubCatId == catid && Inv.StoreBranchId == BLL.Variables._branchIdC
                              from Itm in table1.DefaultIfEmpty()
                              select new InvListM { TInventory = Inv, TItem = Itm };
            return MutilpleTBL;
        }

        //=====================================end Display Orders=====================================================
        public static IEnumerable<OrderDetails> AllDbContextLoadHistory(int orderno)
        {
            SHOPPING_DBContext sd = new SHOPPING_DBContext();

            List<Item> ITMname = sd.Items.ToList();
            List<Order> TOrder = sd.Orders.ToList();

            var MutilpleTBL = from Inv in TOrder
                              join Itm in ITMname on Inv.ItemId equals Itm.ItemId into table2
                              where Inv.OrderNo == orderno 
                              from Itm in table2.DefaultIfEmpty()
                              select new OrderDetails { TOrder = Inv , TItem = Itm  };
            return MutilpleTBL;
        }

        //=====================================end Display Orders based on location=====================================================



        //=====================================Display Orders=====================================================
        /*        public static IEnumerable<OrderDetails> AllDbContextOrderList()
                {
                    SHOPPING_DBContext sd = new SHOPPING_DBContext();

                    List<OrderNumber> TONo = sd.OrderNumbers.ToList();
                    List<Order> TOrd = sd.Orders.ToList();
                    List<Item> Titem = sd.Items.ToList();
                    List<User> Tuser = sd.Users.ToList();
                    List<StoresName> TstoresNames = sd.StoresNames.ToList();
                    List<StoreBranch> Tbranch = sd.StoreBranches.ToList();



                    var result = (from TNum  in TONo
                                  join TLis in TOrd on TNum.OrderNo equals TLis.OrderNo  
                                  join I in Titem on  TLis.ItemId equals I.ItemId
                                  join U in Tuser on TNum.UserPk equals U.UserPk 
                                  join B in Tbranch on TNum.StoreBranchId equals B.StoreBranchId
                                  join S in TstoresNames on B.StoreNameId equals S.StoreNameId into table1
                                  where TNum.StoreBranchId == BLL.Variables._branchIdC && TNum.UserPk == BLL.Variables._userPKC


                                  select new
                                  {
                                      TNum.OrderNo,
                                      TNum.OrderDate,
                                      TLis.Qty,
                                      TLis.UnitPrice,
                                      I.ItemName,
                                      U.Userid,
                                      U.Ustreet,
                                      U.Ucity,
                                      U.Ustate,
                                      U.Uzip,
                                      B.StoreStreet,
                                      B.StoreCity,
                                      B.StoreState,
                                      B.StoreZipcode,
                                      B.StoreName
                                  }).ToList();





                    //var MutilpleTBL = from OrdNo in TONo
                    //                  join OrdL in TOrd on OrdNo.OrderNo equals OrdL.OrderNo into table1
                    //                  where OrdNo.OrderNo ==  orderno && OrdNo.UserPk == BLL.Variables._userPKC
                    //                  from OrdL in table1.DefaultIfEmpty()
                    //                  select new  OrderDetails  { TorderNo =OrdNo, TorderList  = OrdL };
                    return result;






                }
        */






    }


}


