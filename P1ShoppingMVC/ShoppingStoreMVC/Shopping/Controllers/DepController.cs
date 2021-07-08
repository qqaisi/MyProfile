using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Controllers
{
    public class DepController : Controller
    {
        // GET: DepController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DepController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepController/Create
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

        // GET: DepController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepController/Edit/5
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

        // GET: DepController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepController/Delete/5
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
