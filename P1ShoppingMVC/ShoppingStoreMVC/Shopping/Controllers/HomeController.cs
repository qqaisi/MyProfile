using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using RLL;
using Shopping.BLL;


namespace Shopping.Controllers
{
    public class HomeController : Controller
    {


        
        private readonly ILogger<HomeController> _logger;
        
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult SignUp(int id, string street, string city, string state, string zip)
        {


            Variables._branchIdC = id;
            Variables._BStreetC = street;
            Variables._BCityC = city;
            Variables._BStateC = state;
            Variables._BZipC = zip;
            string ss= Variables._StoreNameC + " > " + city + " > " + state;
            ViewBag.Storename = ss;
            
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {

            int found = 0;
            if (model.Userid != "" && model.User_Pwd != "" && model.Userid != null && model.User_Pwd != null)
            {
        
              User Luserid = new User();
                var UserlogedIn = UserProccessor.LoadUser(model.Userid, model.User_Pwd);
                if (UserlogedIn != null)
                { 
                    found = 1;
                    Variables._userPKC = UserlogedIn.UserPk;
                    Variables._branchIdC = UserlogedIn.StoreBranchId;
                    var StoreBranchName = UserProccessor.LoadBranchesLogIn(UserlogedIn.StoreBranchId);
                    if (StoreBranchName != null)
                    {
                        Variables._BStreetC = StoreBranchName[0].StoreStreet;
                        Variables._BCityC = StoreBranchName[0].StoreCity;
                        Variables._BStateC = StoreBranchName[0].StoreState;
                        Variables._BZipC = StoreBranchName[0].StoreZipcode;
                        Variables._storeIdC = StoreBranchName[0].StoreNameId;
                        var StoreName = UserProccessor.LoadStoresID(StoreBranchName[0].StoreNameId);
                        if (StoreName != null)
                            Variables._StoreNameC = StoreName[0].StoreName;
                    }
                }
            }
            string storenameBag = Variables._StoreNameC + " > " + Variables._BCityC + " > " + Variables._BStateC;
            ViewBag.storename = storenameBag;


            if (found==1)
            {

                
                return RedirectToAction("CatList");
            }
            else
            { 
            return RedirectToAction("index");
            }
            //return View("StoresList");

        }






        public ActionResult OrderItemList(int orderno)
        {
            IEnumerable<DataLibrary.OrderDetails> Final = UserProccessor.AllDbContextLoadOrders(orderno);

            
            return View(Final);
        }






        public ActionResult InvItemList(int subcatid)
        {
            //  RStore invlistcount = new InvListM
            //var InvList = UserProccessor.LoadInvItems(subcatid, Variables._branchIdC);
            IEnumerable<DataLibrary.InvListM> Final = UserProccessor.LoadInvItems(subcatid);

            Variables._subCatIdC = subcatid;
                        //for (int i = 0; i < Variables.InvList.Count() ; i++)
                      // {

                        //    Final.Add(new Models.InvListM
                          //  {
                            //ItemName = Variables.InvList[i].ItemName,
                           // Qty = Variables.InvList[i].Qty,
                           // UnitPrice = Variables.InvList[i].UnitPrice,
                           // ItemDesc = Variables.InvList[i].ItemDesc
                           // });
                       // }
                        return View(Final);
        }



        

        public ActionResult ConfirmCart()
        {
            if (ModelState.IsValid)
            {
                int RecordCreated = UserProccessor.ConfirmCart();
                return RedirectToAction("CatList");
            }
            return RedirectToAction("CatList");
        }




        public ActionResult Cart(DataLibrary.Tcart model )
        {
            if (ModelState.IsValid)
            {
                int RecordCreated = UserProccessor.AddToCart(model.Itemid, model.Unitprice, model.Qty, model.Minqty, model.Itemname);
                return RedirectToAction("CatList");
            }
            return RedirectToAction("CatList");
        }

        public ActionResult DeleteFromCart(int id)
        {
            if (ModelState.IsValid)
            {
                var RecordCreated = UserProccessor.DeleteFromCart(id);
                return RedirectToAction("CatList");
            }
            return RedirectToAction("CatList");
        }


        public ActionResult DisplayCart()
        {
               

                var CartData = UserProccessor.LoadCart();
            

                return View("Cart", CartData);
            
        }


        public ActionResult DisplayHistory()
        {
            var HistoryData = UserProccessor.LoadHistroy();
            List<Models.OrderNumber> OrderNumberList = new List<Models.OrderNumber>();

            for (int i = 0; i <= HistoryData.Count() - 1; i++)
            {
                OrderNumberList.Add(new Models.OrderNumber
                {
                    OrderNo = HistoryData[i].OrderNo,
                    OrderDate = HistoryData[i].OrderDate,
                });
            }
            return View("DisplayHistory", OrderNumberList);
        }


        public ActionResult DisplayHistoryReport(int id)
        {
            var HistoryData = UserProccessor.LoadHistroy(id);
            List<Models.OrderNumber> OrderNumberList = new List<Models.OrderNumber>();
            
            for (int i = 0; i <= HistoryData.Count() - 1; i++)
            {
                OrderNumberList.Add(new Models.OrderNumber
                {
                    OrderNo=HistoryData[i].OrderNo,
                    OrderDate = HistoryData[i].OrderDate,
                });
            }
            return View("DisplayHistory", OrderNumberList);
        }
        //========================================orders by location================
        public ActionResult DisplayHistoryByLocation(int branchid)
        {
            var HistoryData = UserProccessor.LoadHistroyByLocation(branchid);
            List<Models.OrderNumber> OrderNumberList = new List<Models.OrderNumber>();

            for (int i = 0; i <= HistoryData.Count() - 1; i++)
            {
                OrderNumberList.Add(new Models.OrderNumber
                {
                    OrderNo = HistoryData[i].OrderNo,
                    OrderDate = HistoryData[i].OrderDate,
                });
            }
            return View("DisplayHistory", OrderNumberList);
        }
        //==============================Stores For reports===============================
        public ActionResult Report1()
        {
            ViewBag.Message = "Stores List";
            var StoresData = UserProccessor.LoadStores();
            List<Models.StoresName> StoresDataList = new List<Models.StoresName>();

            for (int i = 0; i <= StoresData.Count() - 1; i++)
            {
                StoresDataList.Add(new Models.StoresName
                {
                    StoreNameId = StoresData[i].StoreNameId,
                    StoreName = StoresData[i].StoreName
                });
            }

            return View("Report1", StoresDataList);
        }



        public ActionResult Reports(int id, string storename)
        {
            ViewBag.storename = storename;
            Variables._storeIdC = id;
            Variables._StoreNameC = storename;


            var BranchesData = UserProccessor.LoadBranches(id);
            List<Models.StoreBranch> BranchesDataList = new List<Models.StoreBranch>();

            for (int i = 0; i <= BranchesData.Count() - 1; i++)
            {
                BranchesDataList.Add(new Models.StoreBranch
                {
                    StoreBranchId = BranchesData[i].StoreBranchId,
                    StoreNameId = BranchesData[i].StoreNameId,
                    StoreStreet = BranchesData[i].StoreStreet,
                    StoreCity = BranchesData[i].StoreCity,
                    StoreState = BranchesData[i].StoreState,
                    StoreZipcode = BranchesData[i].StoreZipcode,
                    StorePhone = BranchesData[i].StorePhone

                });
            }

            return View("Reports", BranchesDataList);
        }


        //============================End Stores Report ====================

        public ActionResult PostQty( int item_id,float UnitePrice,int Qty ,int  minQty, string  ItemName)
        {
            NewCart myitem = new NewCart();
            myitem.ItemId = item_id;
            myitem.UnitPrice = UnitePrice;
            myitem.Qty = Qty;
            myitem.MinQty = minQty;
            myitem.ItemName = ItemName;
          
            
            return View("PostQty",myitem);
        }



























            public ActionResult StoresList()
            {
            ViewBag.Message = "Stores List";
            var StoresData = UserProccessor.LoadStores();
            List<Models.StoresName> StoresDataList = new List<Models.StoresName>();
            
            for (int i=0; i<=StoresData.Count()-1; i++)
            {
                StoresDataList.Add(new Models.StoresName
                {
                    StoreNameId = StoresData[i].StoreNameId,
                    StoreName = StoresData[i].StoreName
                });
            }
            
            return View("StoresDataList",StoresDataList);
        }

        public ActionResult StoreBranchesList(int id,string storename)
        {
            ViewBag.storename = storename;
            Variables._storeIdC = id;
            Variables._StoreNameC = storename;


            var BranchesData = UserProccessor.LoadBranches(id);
            List<Models.StoreBranch> BranchesDataList = new List<Models.StoreBranch>();
            
            for (int i = 0; i <= BranchesData.Count() - 1; i++)
            {
                BranchesDataList.Add(new Models.StoreBranch
                {
                    StoreBranchId=BranchesData[i].StoreBranchId,
                    StoreNameId=BranchesData[i].StoreNameId,
                    StoreStreet=BranchesData[i].StoreStreet,
                    StoreCity=BranchesData[i].StoreCity,
                    StoreState=BranchesData[i].StoreState,
                    StoreZipcode=BranchesData[i].StoreZipcode,
                    StorePhone=BranchesData[i].StorePhone
                    
                });
            }

            return View("StoreBranchesList", BranchesDataList);
        }


        //=================================Srach by customer============================

        public ActionResult CustomerList()
        {

        


            var CatData = UserProccessor.LoadAllCustomer();
            List<Models.User> CatDataList = new List<Models.User>();

            for (int i = 0; i <= CatData.Count() - 1; i++)
            {
                CatDataList.Add(new Models.User
                {
                    Userid= CatData[i].Userid,
                    Ustreet= CatData[i].Ustreet,
                    Ucity= CatData[i].Ucity,
                    Ustate= CatData[i].Ustate,
                    Uzip= CatData[i].Uzip,
                    UserPk = CatData[i].UserPk

                });
            }

            return View("CustomerList", CatDataList);
        }




        public ActionResult CatList(int id , string street ,string city,string state,string zip)
        {
            

            //Variables._branchIdC = id;
            //Variables._BStreetC = street;
            //Variables._BCityC = city;
            //Variables._BStateC = state;
           //Variables._BZipC = zip;
            ViewBag.Storename = Variables._StoreNameC+" > "+city+" > "+state;


            var CatData = UserProccessor.LoadCats();
            List<Models.ItemsCat> CatDataList = new List<Models.ItemsCat>();

            for (int i = 0; i <= CatData.Count() - 1; i++)
            {
                CatDataList.Add(new Models.ItemsCat
                {
                    CatId = CatData[i].CatId,
                    CatName = CatData[i].CatName
                });
            }

            return View("CatList", CatDataList);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User model)
        {
            if (ModelState.IsValid)
            {
                int RecordCreated = UserProccessor.CreateUser(model.Userid,model.User_Pwd,model.Ustreet,model.Ucity,model.Ustate,model.Uzip,model.Email);
                return RedirectToAction("index");
            }
            
            return View();
        }


        public ActionResult SubCatList(int id, string catname)
        {
            ViewBag.CatName = catname;
            
            var SubCatData = UserProccessor.LoadSubCat(id);
            List<Models.ItemsSubCat> SubCatDataList = new List<Models.ItemsSubCat>();
            Variables._catIdC = id;
            for (int i = 0; i <= SubCatData.Count() - 1; i++)
            {
                SubCatDataList.Add(new Models.ItemsSubCat
                {
                    CatId = SubCatData[i].CatId,
                    SubCatId = SubCatData[i].SubCatId,
                    SubCatName=SubCatData[i].SubCatName
                });
            }

            return View("SubCatList", SubCatDataList);
        }

    }
}
