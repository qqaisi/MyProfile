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


namespace Shopping.RLL
{
    public  class MultipleRepo
    {
        //SHOPPING_DBContext sd = new SHOPPING_DBContext();

        //List<Models.Item> ITMname = context.Items.ToList();
        //List<Models.Inventory> TInv = sd.Inventories.ToList();

        //var MutilpleTBL = from Inv in TInv
        //                  join Itm in ITMname on Inv.ItemId equals Itm.ItemId into table1
        //                  from Itm in table1.DefaultIfEmpty()
        //                  select new Multiple { TInventory = Inv, TItem = Itm };
    }
}
