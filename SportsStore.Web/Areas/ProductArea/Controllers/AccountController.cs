using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Web.Areas.ProductArea.Models;
using SportsStore.Web.Infrastructure.Abstruct;

namespace SportsStore.Web.Areas.ProductArea.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthProvider _authProvider;

        public AccountController(IAuthProvider authProvider)
        {
            _authProvider = authProvider;
        }

        public ViewResult LogOn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogOn(LogOnViewModel logOnViewModel,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_authProvider.Authenticate(logOnViewModel.UserName, logOnViewModel.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("","Incorect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        // GET: ProductArea/Account
        public ActionResult Index()
        {
            return View();
        }
    }
}