using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpisRozmowTelefonicznych.DAL;

namespace SpisRozmowTelefonicznych.Controllers
{
    public class HomeController : Controller
    {
        //SpisContext db = new SpisContext();
        
        public ActionResult Index()
        {
            //UserData user = new UserData { id_UD = 1, name = "Krzysztof", lastName = "Noga" };
            //db.UserDatas.Add(user);
            //db.SaveChanges();




            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult StronyStatyczne(string nazwa)
        {
            return View(nazwa);
        }
    }
}