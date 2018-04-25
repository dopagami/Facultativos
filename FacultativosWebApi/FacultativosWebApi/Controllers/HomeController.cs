using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace FacultativosWebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Facultativos Web Api Home Page";

            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Facultativos Web Api Home Page";

            var userPrinciple = User as ClaimsPrincipal;

            return View(userPrinciple);
        }
    }
}
