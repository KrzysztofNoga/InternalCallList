using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpisRozmowTelefonicznych.ViewModels;
using SpisRozmowTelefonicznych.App_Start;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using SpisRozmowTelefonicznych.DAL;
using System.Drawing;
using SpisRozmowTelefonicznych.Helpers;
using PagedList.Mvc;
using PagedList;
 

namespace SpisRozmowTelefonicznych.Controllers
{
    public class CallController : Controller
    {
        private SpisContext db = new SpisContext();

         
        // GET: Call
        public ActionResult CallList(int ? page)
        {
            if (Request.IsAuthenticated)
            {
                 
                int pagenumber = (page ?? 1);
                var calls = db.Calls.ToList();
                //int pageSize = 5;
                int pageNumber = (page ?? 1);
                var vm = new PagedListViewModel()
                {
                    ListaPolaczen = calls.ToPagedList(page ?? 1, 3)
                };
                var ListaPolaczen = calls.ToPagedList(page ?? 1, 3);



                return View(vm);
            }
            else
                return RedirectToAction("Login", "Account");
        }

        //[ChildActionOnly]
        [HttpGet]
        public  ActionResult CallInfo(int idPolaczenia)
        {
            if (Request.IsAuthenticated)
            //var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            //var userID = db.Users.Select(x=>new Se
            {

                Call polaczenie = db.Calls.Where(c => c.id_call == idPolaczenia).Single();
                string ImieOdb = (from u in db.Users join c in db.Calls on u.Id equals c.UserID where c.id_call == idPolaczenia select u.UserData.name).First();
                string NazwiskoOdb = (from u in db.Users join c in db.Calls on u.Id equals c.UserID where c.id_call == idPolaczenia select u.UserData.lastName).First();
                string NumerOdb = (from p in db.Phones join c in db.Calls on p.id_phone equals c.id_phone where c.id_call == idPolaczenia select p.phone_number).First();
                bool StatusPolaczenieBool = (from c in db.Calls where c.id_call == idPolaczenia select c.status).First();
                var statusPolaczenia = "Nie";
                if (StatusPolaczenieBool)
                    statusPolaczenia = "Tak";
                else statusPolaczenia = "Nie";





                var vmCall = new SzczegolyPolaczeniaViewModel()
                {

                    DataDodania = polaczenie.dataDodania,
                    ImieDzwoniacego = polaczenie.callerName,
                    NazwiskoDzwoniacego = polaczenie.callerLastName,
                    DataPolaczeia = polaczenie.date,
                    NumerDzwoniacego = polaczenie.caller_number,
                    Opis = polaczenie.description,
                    ImieOdbierajacego = ImieOdb,
                    NazwiskoOdbierajacego = NazwiskoOdb,
                    NumerOdbierajacego = NumerOdb,
                    StatusString = statusPolaczenia,
                    callID = polaczenie.id_call





                };



                return View(vmCall);
            }
            else
                return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult CallInfo(SzczegolyPolaczeniaViewModel vmCall)
        {
            if (ModelState.IsValid)
            {
                Call polaczenie = db.Calls.Where(c => c.id_call == vmCall.callID).Single();

                polaczenie.status = vmCall.StatusSprawy;
                db.SaveChanges();
                return RedirectToAction("CallList", "Call");
            }
            else
                return View(vmCall);
                



            

            
            
        }
        private ApplicationUserManager _userManager;

        // GET: Account

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
         
     

        public ActionResult CallList_DataNajstarsze(int ? page)
        {
            if (Request.IsAuthenticated)
            {
                 
                int pagenumber = (page ?? 1);
                int pageNumber = (page ?? 1);
                string ID = User.Identity.GetUserId();
                var calls = db.Calls.Where(a => a.adresseID == ID || a.UserID == ID).OrderBy(x => x.date).ToList();
                var vm = new PagedListViewModel()
                {
                    ListaPolaczen = calls.ToPagedList(page ?? 1,3)
                };
                
                return View(vm);
            }
            else
                return RedirectToAction("Login", "Account");

        }

        public ActionResult CallList_DataNajnowsze(int ? page)
        {
            if (Request.IsAuthenticated)
            {
                int pagenumber = (page ?? 1);
                int pageNumber = (page ?? 1);

                string ID = User.Identity.GetUserId();
                var calls = db.Calls.Where(a => a.adresseID == ID || a.UserID == ID).OrderByDescending(x => x.date).ToList();
                var vm = new PagedListViewModel()
                {
                    ListaPolaczen = calls.ToPagedList(page ?? 1, 3)
                };
                return View(vm);
            }
            else
                return RedirectToAction("Login", "Account");


        }

        public ActionResult CallList_TylkoDlaMnie(int ? page)
        {
            if (Request.IsAuthenticated)
            {
                int pagenumber = (page ?? 1);
                int pageNumber = (page ?? 1);

                string ID = User.Identity.GetUserId();
                var calls = db.Calls.Where(a => a.adresseID == ID).ToList();
                var vm = new PagedListViewModel()
                {
                    ListaPolaczen = calls.ToPagedList(page ?? 1,3)
                };
                return View(vm);
            }
            else
                return RedirectToAction("Login", "Account");

        }

        public ActionResult CallList_OdebranePrzezeMnie(int ? page)
        {
            if (Request.IsAuthenticated)
            {
                int pagenumber = (page ?? 1);
                int pageNumber = (page ?? 1);

                string ID = User.Identity.GetUserId();
                var calls = db.Calls.Where(a => a.UserID == ID).ToList();
                var vm = new PagedListViewModel()
                {
                    ListaPolaczen = calls.ToPagedList(page ?? 1,3)
                };
                return View(vm);
            }
            else
                return RedirectToAction("Login", "Account");

        }

        public ActionResult CallList_StatusTAK(int ? page)
        {
            if (Request.IsAuthenticated)
            {

                int pagenumber = (page ?? 1);
                int pageNumber = (page ?? 1);

                string ID = User.Identity.GetUserId();
                var calls = db.Calls.Where(a => a.adresseID == ID && a.status).ToList();
                var vm = new PagedListViewModel()
                {
                    ListaPolaczen = calls.ToPagedList(page ?? 1,3)
                };
                return View(vm);
            }
            else
                return RedirectToAction("Login", "Account");

        }

        public ActionResult CallList_StatusNIE(int ? page)
        {
            if (Request.IsAuthenticated)
            {
                int pagenumber = (page ?? 1);
                int pageNumber = (page ?? 1);

                string ID = User.Identity.GetUserId();
                var calls = db.Calls.Where(a => a.adresseID == ID && !a.status).ToList();
                var vm = new PagedListViewModel()
                {
                    ListaPolaczen = calls.ToPagedList(page ?? 1,3)
                };
                return View(vm);
            }
            else
            return RedirectToAction("Login", "Account");

        }

    }
}