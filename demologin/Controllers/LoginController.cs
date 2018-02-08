using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demologin.Models;

namespace demologin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(demologin.Models.User userModel)
        {
            using (DevDBContext dblogin = new DevDBContext())
            {
                var userlogin = dblogin.Users.Where(u => u.Username == userModel.Username
                  && u.Password == userModel.Password).SingleOrDefault();

                if (userlogin == null)
                {
                    userModel.LoginError = "Invalid username and password";
                    return View("Index", userModel);
                }
                else
                {
                    Session["username"] = userlogin.Username;
                    return RedirectToAction("Index", "Home");
                }

            }
        }
    }
}