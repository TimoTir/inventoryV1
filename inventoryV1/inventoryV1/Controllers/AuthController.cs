using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using inventoryV1.Controllers;

namespace inventoryV1.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Index(users u)
        {
            invisDBEntities obj = new invisDBEntities();
            var data = obj.st_getLoginDetails(u.username, u.password);
            foreach(var item in data)
            {
                if (item.Username== u.username && item.Password == u.password)
                {
                    Session["name"] = u.username;
                    return RedirectToAction("Main");
                }
                else
                {

                }
            }
            return View();
        }
    }
}