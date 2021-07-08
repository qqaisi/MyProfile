using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.Extensions.Logging;

namespace Shopping.Controllers
{
    public class InvController : Controller
    {
        // GET: InvController
        private readonly ILogger<InvController> _logger;

        private readonly IInvItem _Inv;


        public InvController(IInvItem  inv, ILogger<InvController> logger)
        {
            this._Inv = inv;
            this._logger = logger;

        }
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> InvList()
        {
            List<Models.Inventory> InvList = await _Inv.InvListAsync();
            return View(InvList);
        }

        // GET: InvController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InvController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvController/Create
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

        // GET: InvController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvController/Edit/5
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

        // GET: InvController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InvController/Delete/5
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
