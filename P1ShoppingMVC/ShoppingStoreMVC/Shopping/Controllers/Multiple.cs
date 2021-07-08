using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopping.BLL;

namespace Shopping.Controllers
{
    public class Multiple : Controller
    {
        public IActionResult Index(int subcatid)
        {
            //var InvList = UserProccessor.LoadInvItems(subcatid, Variables._branchIdC);
            //return View("InvList");
            return View();
            
        }
    }
}
