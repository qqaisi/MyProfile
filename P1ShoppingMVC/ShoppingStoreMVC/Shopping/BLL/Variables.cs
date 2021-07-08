using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;


namespace Shopping.BLL
{
    public class Variables
    {
        public static int _userPKC = 0;
        public static int _storeIdC = 0;
        public static int _branchIdC = 0;
        public static int _catIdC = 0;
        public static int _subCatIdC = 0;
        public static int _itemIdC = 0;
        public static string _UserIdC = "";
        public static string _StreetC = "";
        public static string _CityC = "";
        public static string _StateC = "";
        public static string _ZipC = "";
        public static string _BStreetC = "";
        public static string _BCityC = "";
        public static string _BStateC = "";
        public static string _BZipC = "";
        public static string _CatNameC = "";
        public static string _SubCatNameC = "";
        public static string _StoreNameC = "";
        public static double _TotalC = 0;
        public static List<Models.InvListM> InvList;
        public static Cart cartitems;
        public static List<Cart> _CartList;

        public static int _Qty = 0;

       


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

        public double TotalC
        {
            get
            {
                return _TotalC;
            }
            set
            {
                _TotalC = value;

            }
        }

        public string StoreNameC
        {
            get
            {
                return _StoreNameC;
            }
            set
            {
                _StoreNameC = value;

            }
        }
        public string UserIdC
        {
            get
            {
                return _UserIdC;
            }
            set
            {
                _UserIdC = value;

            }
        }

        public string StreetC
        {
            get
            {
                return _StreetC;
            }
            set
            {
                _StreetC = value;

            }
        }

        public string CityC
        {
            get
            {
                return _CityC;
            }
            set
            {
                _CityC = value;

            }
        }

        public string StateC
        {
            get
            {
                return _StateC;
            }
            set
            {
                _StateC = value;

            }
        }

        public string ZipC
        {
            get
            {
                return _ZipC;
            }
            set
            {
                _ZipC = value;

            }
        }

        public string BStreetC
        {
            get
            {
                return _BStreetC;
            }
            set
            {
                _BStreetC = value;

            }
        }

        public string BCityC
        {
            get
            {
                return _BCityC;
            }
            set
            {
                _BCityC = value;

            }
        }


        public string BStateC
        {
            get
            {
                return _BStateC;
            }
            set
            {
                _BStateC = value;

            }
        }

        public string BZipC
        {
            get
            {
                return _BZipC;
            }
            set
            {
                _BZipC = value;

            }
        }

        public string CatNameC
        {
            get
            {
                return _CatNameC;
            }
            set
            {
                _CatNameC = value;

            }
        }

        public string SubCatNameC
        {
            get
            {
                return _SubCatNameC;
            }
            set
            {
                _SubCatNameC = value;

            }
        }
        public int itemIdC
        {
            get
            {
                return _itemIdC;
            }
            set
            {
                if (value != 0)
                {
                    _itemIdC = value;
                }
            }
        }

        public int subCatIdC
        {
            get
            {
                return _subCatIdC;
            }
            set
            {
                if (value != 0)
                {
                    _subCatIdC = value;
                }
            }
        }

        public int catIdC
        {
            get
            {
                return _catIdC;
            }
            set
            {
                if (value != 0)
                {
                    _catIdC = value;
                }
            }
        }

        public int branchIdC
        {
            get
            {
                return _branchIdC;
            }
            set
            {
                if (value != 0)
                {
                    _branchIdC = value;
                }
            }
        }

        public int storeIdC
        {
            get
            {
                return _storeIdC;
            }
            set
            {
                if (value != 0)
                {
                    _storeIdC = value;
                }
            }
        }

        public int userPKC
        {
            get
            {
                return _userPKC;
            }
            set
            {
                if (value != 0)
                {
                    _userPKC = value;
                }
            }
        }

        public  Variables()
        { 
        }
        public Variables(int userpkc, int storeidc, int branchidc, int catidc, int subcatidc, int itemidc,string useidc,
            string streetc,string cityc, string statec, string zipc, string bstreetc, string bcityc,string bstatec, 
            string bzipc,string catnamec, string subcatnamec,float total,int Qty)
        
        {
            this.Qty = Qty;
            this.userPKC = userpkc;
            this.storeIdC = storeidc;
            this.branchIdC = branchidc;
            this.catIdC = catidc;
            this.subCatIdC = subcatidc;
            this.itemIdC = itemidc;
            this.UserIdC = useidc;
            this.StreetC = streetc;
            this.CityC = cityc;
            this.StateC = statec;
            this.ZipC = zipc;
            this.BStreetC = bstatec;
            this.BCityC = bcityc;
            this.BStateC = bstatec;
            this.BZipC = bzipc;
            this.CatNameC = catnamec;
            this.SubCatNameC = subcatnamec;
            this.TotalC = total;


        }



    }
}
