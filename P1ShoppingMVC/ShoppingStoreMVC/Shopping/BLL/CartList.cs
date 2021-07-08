using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.BLL
{
    public class CartList
    {
        public  List<Cart> CartListB { get; set; }
        //public List<Cart> CartObj = new List<Cart>() ;
        public CartList()
        {
            List<Cart> CartObj = new List<Cart>();
        }
       
     
    }
}
