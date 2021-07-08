using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDbContext.Models;
namespace ShopStore
{
    public class AddToCart
    {

        private float _Total;

        public float Total
        {
            get
            {
                return _Total;
            }
            set
            {
                _Total = value;
            }
        }

        public  float  AddToCartTotal(float total,float unitprice, int qty)
        {
            total = total + (unitprice*qty);
            this.Total = total;
            return Total;
        }
    }
}
