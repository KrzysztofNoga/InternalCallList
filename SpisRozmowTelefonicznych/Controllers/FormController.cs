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


 


namespace SpisRozmowTelefonicznych.Controllers
{
    public class FormController : Controller
    {
        private CallMenager CallMenager;
        private SpisContext db;

        public FormController()
        {

        }
        public FormController(SpisContext context,ISessionMenager session)
        {
            this.db = context;
            CallMenager = new CallMenager(session, db);
            
                  }

        //public ActionResult Form()
        //{
        //    return View();
        //}

        // GET: Form

        //public async Task<ActionResult> Form(FormularzViewModel model)
        //{
        //    //SpisContext db = new SpisContext();

        //       // model.Phones = new SelectList(db.Phones, "phone_number");

        //        //var modelDDL = new ListPhoneView()
        //        //{
        //        //    Telefony = db.Phones.Select(x => new SelectListItem
        //        //    {
        //        //        Value = x.id_phone.ToString(),
        //        //        Text = x.phone_number



        //        //    })

        //        //};
        //        if (Request.IsAuthenticated)
        //        {
        //            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
        //            //model.Telefony = db.Phones.Select(x => new SelectListItem
        //            //{
        //            //    Value = x.id_phone.ToString(),
        //            //    Text = x.phone_number
        //            //});
        //            //int id = (from p in db.Phones where p.phone_number == model.PHONE_NUMBER select p.id_phone).First();


        //            Call call = new Call
        //            {
        //                id_call = 1,
        //                date = model.Date,
        //                description = model.Description,
        //                callerName = model.NameCaller,
        //                callerLastName = model.LastNaemCaller,
        //                status = false,
        //                adresseID = user.Id,
        //                caller_number = model.PHONE_NUMBER_CALLER,
        //                id_phone = 1
        //            };


        //            return View(call);
        //        }
        //        else

        //        return RedirectToAction("Login","Account");




        //}
        

        //[HttpGet]
        //public async Task<ActionResult> Form(FormularzViewModel model)
        //{
        //    //SpisContext db = new SpisContext();

        //    // model.Phones = new SelectList(db.Phones, "phone_number");

        //    //var modelDDL = new ListPhoneView()
        //    //{
        //    //    Telefony = db.Phones.Select(x => new SelectListItem
        //    //    {
        //    //        Value = x.id_phone.ToString(),
        //    //        Text = x.phone_number



        //    //    })

        //    //};
        //    //if (Request.IsAuthenticated)
        //    if (ModelState.IsValid)
        //    { var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
        //        var userID = User.Identity.GetUserId();
        //        //model.Telefony = db.Phones.Select(x => new SelectListItem
        //        //{
        //        //    Value = x.id_phone.ToString(),
        //        //    Text = x.phone_number
        //        //});
        //        //int id = (from p in db.Phones where p.phone_number == model.PHONE_NUMBER select p.id_phone).First();
        //        Call call = new Call
        //        {
        //            id_call = 1,
        //            date = model.Date,
        //            description = model.Description,
        //            callerName = model.NameCaller,
        //            callerLastName = model.LastNaemCaller,
        //            status = false,
        //            adresseID = userID,
        //            caller_number = model.PHONE_NUMBER_CALLER,
        //            id_phone = 1
        //        };




        //        return View(call);


        //    }
        //    else

        //        return View(model);
             
         



        //}

        //[HttpPost]
        //public ActionResult Form(Call call)
        //{
                
        //    if (ModelState.IsValid)
        //    {
        //        var userId = User.Identity.GetUserId();
              

                
        //        var newCall = CallMenager.CreateCall(call, userId);
        //        return RedirectToAction("Index", "Home");
        //    }


        //    else
        //        return View(call);
        //}

        //Zapisz


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

        [HttpGet]
        public async Task<ActionResult> Form()
        {
            if (Request.IsAuthenticated)
            {
                SpisContext DTB = new SpisContext();

                //SpisContext db = new SpisContext();

                // model.Phones = new SelectList(db.Phones, "phone_number");

                //var modelDDL = new ListPhoneView()
                //{
                //    Telefony = db.Phones.Select(x => new SelectListItem
                //    {
                //        Value = x.id_phone.ToString(),
                //        Text = x.phone_number

                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                var userID = User.Identity.GetUserId();
                FormularzViewModel model = new FormularzViewModel();
                model.DoKogo = DTB.Users.Select(x => new SelectListItem
                {
                    Value = x.Id,
                    Text = x.UserData.lastName + " " + x.UserData.name

                });

                model.TelefonyUsera = DTB.Phones.Select(y => new SelectListItem
                {
                    Value = y.id_phone.ToString(),
                    Text = y.phone_number
                });





                //    })

                //};
                //if (Request.IsAuthenticated)
                if (ModelState.IsValid)
                {
                    //var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                    //var userID = User.Identity.GetUserId();

                    //model.Telefony = db.Phones.Select(x => new SelectListItem
                    //{
                    //    Value = x.id_phone.ToString(),
                    //    Text = x.phone_number
                    //});
                    //int id = (from p in db.Phones where p.phone_number == model.PHONE_NUMBER select p.id_phone).First();





                    return View(model);


                }
                else

                    return View(model);
            }
            else
                return RedirectToAction("Login", "Account");




        }

        [HttpPost]
        public ActionResult Form(FormularzViewModel model)
        {
            SpisContext DTB = new SpisContext();

            if (ModelState.IsValid)
            {

                
                int id = (from p in DTB.Phones where p.phone_number == model.PHONE_NUMBER select p.id_phone).First();
                var DK = model.DoKogo;
                var TO = model.TelefonyUsera;

                var userID = User.Identity.GetUserId();
                //int myChosePhone=100;
                //string a = model.SelectedTelefon;
                //int parsedInt = 0;
                //if (int.TryParse(a, out parsedInt))
                //    myChosePhone = parsedInt;

                    
                
                Call call = new Call
                {
                     
                    date = model.Date,
                    description = model.Description,
                    callerName = model.NameCaller,
                    callerLastName = model.LastNaemCaller,
                    status = false,
                    adresseID = model.SelectedDoKogo,
                    caller_number = model.PHONE_NUMBER_CALLER,
                    id_phone = id,
                    dataDodania = DateTime.Now,
                    UserID=userID,
                    
                    
                    


            };
                DTB.Calls.Add(call);
                DTB.SaveChanges();


                //var newCall = CallMenager.CreateCall(call, userID);
                return RedirectToAction("CallList_TylkoDlaMnie", "Call");
            }


            else
                return View(model);
        }

      
    }
    }
