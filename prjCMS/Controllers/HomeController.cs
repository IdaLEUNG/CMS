using prjCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace prjCMS.Controllers
{
    public class HomeController : Controller
    {

        dbCMSEntities db = new dbCMSEntities();

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.ListMake = db.cMakes.Distinct()
                                 .OrderBy(m => m.cmMake)
                                 .ToList();
            ViewBag.ListModel = db.cModels.Distinct()
                                 .OrderBy(m => m.cmModel)
                                 .ToList();
            ViewBag.ListBody = db.cBodies.Distinct()
                                 .OrderBy(m => m.cbName)
                                 .ToList();
            ViewBag.ListFuel = db.cFuels.Distinct()
                                 .OrderBy(m => m.cfName)
                                 .ToList();
            ViewBag.ListGear = db.cGears.Distinct()
                                 .OrderBy(m => m.cgName)
                                 .ToList();
            ViewBag.ListColor = db.cColors.Distinct()
                                 .OrderBy(m => m.crName)
                                 .ToList();
            ViewBag.ListEngine = db.cEngines.Distinct()
                                 .OrderBy(m => m.ceType)
                                 .ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Index(cCar srchCar)
        {
            try
            {
                return RedirectToAction("Search", srchCar);
            }
            catch (Exception ex)
            { }

            return View();
        }

        // GET: Home
        // public ActionResult Search(List<cCar> car)
        public ActionResult Search(cCar srchCar)
        {
            decimal tmpDec = 0;

            IQueryable<cCar> query = db.cCars.AsQueryable();

            if (srchCar.cMake != null && srchCar.cMake != "") // Make
            {
                query = query
                        .Where(m => m.cMake == srchCar.cMake);
            }
            if (srchCar.cBody != null && srchCar.cBody != "") // Body
            {
                query = query
                        .Where(m => m.cBody == srchCar.cBody);
            }
            if (srchCar.cFuel != null && srchCar.cFuel != "") // Fuel
            {
                query = query
                        .Where(m => m.cFuel == srchCar.cFuel);
            }
            if (srchCar.cGear != null && srchCar.cGear != "") // Gear
            {
                query = query
                        .Where(m => m.cGear == srchCar.cGear);
            }
            if (srchCar.cColor != null && srchCar.cColor != "") // Color
            {
                query = query
                        .Where(m => m.cColor == srchCar.cColor);
            }

            if (srchCar.cEngine != null && srchCar.cEngine != 0) // Engine
            {
                tmpDec = Convert.ToDecimal(srchCar.cEngine);
                query = query
                      .Where(m => m.cEngine == tmpDec);
            }

            var car = query.ToList();
            
            return View(car);
        }

        public ActionResult Detail(int cId) 
        {
            var car = db.cCars
                      .Where(m => m.cId == cId).FirstOrDefault();
            ViewBag.ImageURL = car.cPhoto;
            return View(car);
        }


        // GET: Home
        public ActionResult Contact()
        {
            return View();
        }

        // GET: Home
        public ActionResult About()
        {
            return View();
        }

        // GET: Home
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string cUserId, string cPwd)
        {
            
            var user = db.cAdmins
                        .Where(m => m.cUserId == cUserId && m.cPwd == cPwd)
                        .FirstOrDefault();

            if (user == null)
            {
                ViewBag.Message = "Incorrect Username/Password";
                return View();
            }
            Session["Welcome"] = "Hello, " + user.cName;

            FormsAuthentication.RedirectFromLoginPage(cUserId, true);

            return RedirectToAction("Function", "Admin");
        }
    }
}