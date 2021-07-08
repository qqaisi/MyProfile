using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDbContext.Models;
namespace ShopStore
{
    public class SelectStore
    {


        

        private int _StoreID;
        private string _StoreName;


        public int StoreID
        {
            get
            {
                return _StoreID;
            }
            set 
            {
                _StoreID = value;
            }
        }

        public string StoreName
        {
            get
            {
                return _StoreName;
            }
            set
            {
                _StoreName = value;
            }

        }


        public SelectStore()
        {
            SHOPPING_DBContext context = new SHOPPING_DBContext();

            var StoreS= context.StoresNames.ToList();
            foreach (StoresName s in context.StoresNames)
            {
                Console.WriteLine($"[ {s.StoreNameId} ]===>   {s.StoreName}  ");
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"[ 0 ]===>   To Exit  ");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");

            Console.WriteLine("Choose the store that you would like to shop from :");
            
            int Choose;
            while (!int.TryParse(Console.ReadLine(), out Choose) || !(Choose <= StoreS.Count() && Choose >= 0))
            {
                Console.WriteLine("That was invalid. Enter a valid number");
            }
            if (Choose != 0)
           this.StoreName = context.StoresNames.Where(s => s.StoreNameId == Choose).Single().StoreName;
           this._StoreID = Choose;
        } 
            
            
            
         
        

    }


}
