using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpisRozmowTelefonicznych.Controllers
{
    public class WidokController : Controller
    {
        // GET: Widok
        public ActionResult Widok()
        {
            return View();
        }

        public ActionResult Logowanie()
        {
            return View();
        }
        public ActionResult DodawaniePolaczenia()
        {
            return View();
        }

    }
}