using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDbContext.Models;
namespace ShopStore
{
    public class SubCat
    {


        private int _SubCatId;
        private string _SubCatName;


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


        public string SubCatName
        {
            get
            {
                return _SubCatName;
            }
            set
            {
                _SubCatName = value;
            }
        }



        public SubCat(int TCadId)
        {
            SHOPPING_DBContext context = new SHOPPING_DBContext();
            //this._StoreID = Choose;
            var SubCatList = context.ItemsSubCats.Where(s => s.CatId == TCadId).ToList();
            //foreach (StoreBranch s in context.StoreBranches)
            for (int i = 0; i <= SubCatList.Count - 1; i++)
            {
                Console.WriteLine($"[ {i+1} ]===>   {SubCatList[i].SubCatName} ");
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"[ 0 ]===>   Go To Previous Menu  OR    [99] To Review Your Cart  ");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");

            Console.WriteLine("Choose the Department that you would like to shop from :");
            //string valid = Console.ReadLine();

            int Choose;
            while (!int.TryParse(Console.ReadLine(), out Choose) || !(Choose <= SubCatList.Count && Choose >= 0))
            {
                Console.WriteLine("That was invalid. Enter a valid number");

            }
            if (Choose != 0)
            {

                this.SubCatId = SubCatList[Choose-1].SubCatId;
                this.SubCatName = SubCatList[Choose - 1].SubCatName;
            }


        }
    }
}
