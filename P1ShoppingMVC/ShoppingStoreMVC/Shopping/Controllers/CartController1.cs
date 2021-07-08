using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopping.Models;

namespace Shopping.Controllers
{
    public class CartController1 : Controller
    {
        // GET: CartController1
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult CartCont(InvListM itemInfo)
        {

            var x = new InvListM();
            var d= x.TItem.ItemDesc;
            var e = x.TInventory.MinQty;
            //ViewBag.Name = name;
            return View();
        }



        // GET: CartController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
