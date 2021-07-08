using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDbContext.Models;

namespace ShopStore
{
    class Department
    {

        private int _Catid;
        private string _CatName;
        

        public int CatId
        {
            get
            {
                return _Catid;
            }
            set
            {
                _Catid = value;
            }
        }
        public string CatName
        {
            get
            {
                return _CatName;
            }
            set
            {
                _CatName = value;
            }
        }




        public Department()
        {
            SHOPPING_DBContext context = new SHOPPING_DBContext();
            var CatSet = context.ItemsCats.ToList();
            foreach (ItemsCat s in context.ItemsCats)
            {
                Console.WriteLine($"[ {s.CatId} ]===>   {s.CatName}  ");
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"[ 0 ]===>   Go To Previous Menu  OR    [99] To See Location invoices  ");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");

            Console.WriteLine("Choose the Department that you would like to shop from :");

            int Choose;
            while (!int.TryParse(Console.ReadLine(), out Choose) || !(Choose <= CatSet.Count && Choose >= 0))
            {
                Console.WriteLine("That was invalid. Enter a valid number");
            }
            if (Choose != 0)
                this.CatName = context.ItemsCats.Where(s => s.CatId == Choose).Single().CatName;
                this._Catid = Choose;

            Console.Clear();
            //locationhistorty LocHis  = new locationhistorty(Cart_List, UserName, addressm, city, State, zip, storeName, StoreStreet, storecity, storestate,
            //storezip, storephone, TotInvoice, userPK);
        }


    }
}
