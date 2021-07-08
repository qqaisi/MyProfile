using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
namespace Shopping.Controllers
{
    public class UserDiController1 : Controller
    {
        // GET: UserDiController
        // 1
        private readonly ILogger<UserDiController1> _logger;

        private readonly IUserDi _userDi;
        public UserDiController1(IUserDi user, ILogger<UserDiController1> logger)
        {
            this._userDi = user;
            this._logger = logger;
        }

        public async Task<ActionResult> UserDiList()
        {
            List<Models.User> UserList = await _userDi.UserListAsync();
            return View(UserList);
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: UserDiController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserDiController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserDiController1/Create
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

        // GET: UserDiController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserDiController1/Edit/5
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

        // GET: UserDiController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserDiController1/Delete/5
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
