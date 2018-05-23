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

namespace SpisRozmowTelefonicznych.Controllers
{
    
    public class ListaRozwijalnaController : Controller
    {
        //GET: ListaRozwijalna

       
        //public ActionResult ListaTelefonow()
        //{
        //    return View();
        //}
        public  ActionResult ListaTelefonow()
        {
            
            SpisContext db = new SpisContext();
            var model = new ListPhoneView()
            {
                Telefony = db.Phones.Select(x => new SelectListItem 
                {
                    Value = x.id_phone.ToString(),
                    Text = x.phone_number
                    


                })
                
            };
            

            return View(model);
        }

        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}

        //public IEnumerable<SelectListItem> GetPhoneNumbers()
        //{
        //    List<SelectListItem> ddl = new List<SelectListItem>();
        //    int currentYear = DateTime.Now.Year;

        //    for (int i = currentYear - 10; i < currentYear; i++)
        //    {
        //        ddl.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
        //    }

        //    IEnumerable<SelectListItem> lastTenYears = ddl;

        //    return lastTenYears;
        //}

        //public ActionResult ListaTelefonow()
        //{
        //    ListPhoneView model = new ListPhoneView();
        //    model.Telefony = GetPhoneNumbers();  //get the drop down list

        //    return View(model); //we're passing our Model to the view
        //}

    }
}