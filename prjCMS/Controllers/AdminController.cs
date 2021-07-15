using prjCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace prjCMS.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        dbCMSEntities db = new dbCMSEntities();

        // GET: Admin
        public ActionResult Function()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // Add
        public ActionResult Add()
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
        public ActionResult Add(cCar newCar)
        {
            // Validation

            db.cCars.Add(newCar);
            db.SaveChanges();

            return RedirectToAction("Function", "Admin");
        }

        // Edit or Delete
        public ActionResult Update()
        {
            var car = db.cCars
                      .OrderBy(m => m.cId);
            return View(car);
        }

        public ActionResult Delete(int cId)
        {
            var delCar = db.cCars
                        .Where(m => m.cId == cId)
                        .FirstOrDefault();
            db.cCars.Remove(delCar);
            db.SaveChanges();

            return RedirectToAction("Update", "Admin");
        }

        public ActionResult Edit(int cId)
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

            var edtCar = db.cCars
                        .Where(m => m.cId == cId)
                        .FirstOrDefault();

            return View(edtCar);
        }

        [HttpPost]
        public ActionResult Edit(cCar edtCar)
        {
            // Validation

            var selCar = db.cCars
                        .Where(m => m.cId == edtCar.cId)
                        .FirstOrDefault();
            selCar.cMake = edtCar.cMake;
            selCar.cModel = edtCar.cModel;
            selCar.cYear = edtCar.cYear;
            selCar.cGear = edtCar.cGear;
            selCar.cBody = edtCar.cBody;
            selCar.cFuel = edtCar.cFuel;
            selCar.cDoor = edtCar.cDoor;
            selCar.cColor = edtCar.cColor;
            selCar.cPhoto = edtCar.cPhoto;
            selCar.cMileage = edtCar.cMileage;
            selCar.cEngine = edtCar.cEngine;

            db.SaveChanges();
            return RedirectToAction("Update", "Admin");
            // return Content(@"<script>window.close();</script>", "text/html");
        }
    }
}