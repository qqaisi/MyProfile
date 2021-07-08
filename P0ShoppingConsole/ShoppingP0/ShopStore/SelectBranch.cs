using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDbContext.Models;

namespace ShopStore
{
    public class SelectBranch
    {

            private int _StoreBranchId;
            private string _StoreStreet;
            private string _StoreCity;
            private string _StoreState;
            private string _StoreZipCode;
            private string _StorePhone;


        public int StoreBranchId
        {
                get
                {
                    return _StoreBranchId;
                }
                set
                {
                    _StoreBranchId = value;
                }
        }

        public string StoreStreet
        {
            get
            {
                return _StoreStreet;
            }
            set
            {
                _StoreStreet = value;
            }
        }

        public string StoreCity
        {
            get
            {
                return _StoreCity;
            }
            set
            {
                _StoreCity = value;
            }
        }

        public string StoreState
        {
            get
            {
                return _StoreState;
            }
            set
            {
                _StoreState = value;
            }
        }
        public string StoreZipCode
        {
            get
            {
                return _StoreZipCode;
            }
            set
            {
                _StoreZipCode = value;
            }
        }
        public string StorePhone
        {
            get
            {
                return _StorePhone;
            }
            set
            {
                _StorePhone = value;
            }
        }



        public SelectBranch(int S_N_Id)
            {
                SHOPPING_DBContext context = new SHOPPING_DBContext();
                //this._StoreID = Choose;
                var StoreBranchsList = context.StoreBranches.Where(s => s.StoreNameId == S_N_Id).ToList();


                Console.WriteLine("[         Street       ]       [   City    ]        [  State  ]           [ ZIP CODE ]       [ Pone Number ]");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------");

                //foreach (StoreBranch s in context.StoreBranches)
                for (int i= 0; i<=StoreBranchsList.Count-1; i++)
                {
                        Console.WriteLine($"[ {StoreBranchsList[i].StoreStreet.PadRight(20)} ]===>   {StoreBranchsList[i].StoreCity.PadRight(20)} - {StoreBranchsList[i].StoreState.PadRight(20)} - {StoreBranchsList[i].StoreZipcode.PadRight(15)} - {StoreBranchsList[i].StorePhone.PadRight(15)}  ");
                }
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"[ 0 ]===>   Go To Previous Menu  ");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Choose the store  Branch that you would like to shop from :");
                //string valid = Console.ReadLine();

                int Choose;
                while (!int.TryParse(Console.ReadLine(), out Choose) || !(Choose <= StoreBranchsList.Count && Choose >= 0))
                {
                    Console.WriteLine("That was invalid. Enter a valid number");
                
                }
                if (Choose!=0)
                { 
                this.StoreBranchId = Choose;
                this.StoreStreet = StoreBranchsList[Choose - 1].StoreStreet;
                this.StoreCity = StoreBranchsList[Choose - 1].StoreCity;
                this.StoreState = StoreBranchsList[Choose - 1].StoreState;
                this.StoreZipCode = StoreBranchsList[Choose - 1].StoreZipcode;
                this.StorePhone = StoreBranchsList[Choose - 1].StorePhone;
                }


        }


    }


}





