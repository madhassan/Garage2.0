using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2._0.DataAccessLayer;
using Garage2._0.Models;

namespace Garage2._0.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private StorageContext db = new StorageContext();

        // GET: ParkedVehicles
        public ViewResult Index(string searchString,string sortOrder)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.typeSortParm = sortOrder == "type" ? "type_desc" : "type";
            ViewBag.ColorSortParm = sortOrder == "Color" ? "Color_desc" : "Color";
            ViewBag.BrandSortParm = sortOrder == "Brand" ? "Brand_desc" : "Brand";
            ViewBag.ModelSortParm = sortOrder == "Model" ? "Model_desc" : "Model";
            ViewBag.NoOfWheelsSortParm = sortOrder == "NoOfWheels" ? "NoOfWheels_desc" : "NoOfWheels";


            var parkedvehicles = from p in db.parkedVehicles select p;
            //VehicleType type = (VehicleType)Enum.Parse(typeof(VehicleType), (searchString));

            if (!String.IsNullOrEmpty(searchString))
            {
                parkedvehicles = db.parkedVehicles.Where(p => p.RegistrationNumber.ToUpper().Contains(searchString.ToUpper())
                 || p.Color.ToUpper().Contains(searchString.ToUpper())
                 || p.type.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    parkedvehicles = parkedvehicles.OrderByDescending(v => v.RegistrationNumber);
                    break;

                case "type":
                    parkedvehicles = parkedvehicles.OrderBy(v => v.type);
                    break;

                case "type_desc":
                    parkedvehicles = parkedvehicles.OrderByDescending(v => v.type);
                    break;

                case "Color":
                    parkedvehicles = parkedvehicles.OrderBy(v => v.Color);
                    break;

                case "Color_desc":
                    parkedvehicles = parkedvehicles.OrderByDescending(v => v.Color);
                    break;

                case "Brand":
                    parkedvehicles = parkedvehicles.OrderByDescending(v => v.Brand);
                    break;

                case "Brand_desc":
                    parkedvehicles = parkedvehicles.OrderBy(v => v.Brand);
                    break;

                case "Model":
                    parkedvehicles = parkedvehicles.OrderBy(v => v.Model);
                    break;

                case "Model_desc":
                    parkedvehicles = parkedvehicles.OrderByDescending(v => v.Model);
                    break;

                case "NoOfWheels":
                    parkedvehicles = parkedvehicles.OrderBy(v=> v.NoOfWheels);
                    break;

                case "NoOfWheels_desc":
                    parkedvehicles = parkedvehicles.OrderByDescending(v => v.NoOfWheels);
                    break;

                default:
                    parkedvehicles = parkedvehicles.OrderByDescending(v => v.RegistrationNumber);
                    break;
            }


            return View(parkedvehicles.ToList());
        }

        //public ActionResult Index()
        //{
        //    return View(db.parkedVehicles.ToList());
        //}

        //Receipt
        public ActionResult Receipt()
        {
            //List<Receipt> receipts = new List<Receipt>();
            //foreach (ParkedVehicle p in db.parkedVehicles)
            //{
            //    receipts.Add(new Models.Receipt(p));
            //}

            var receipts = from p in db.parkedVehicles
                           select new { p.RegistrationNumber,p.type,p.CheckInTime,p.CheckOutTime};
            return View(receipts);
        }


        // GET: Overview-View ParkedVehicles
        public ActionResult OverviewView()
        {
            List<Overview> overviews = new List<Overview>();
            foreach (ParkedVehicle p in db.parkedVehicles)
            {
                overviews.Add(new Overview(p));
            }
            //var model = from p in overviews
            //            select new { p.RegistrationNumber, p.Type, p.Color};
            
            return View(overviews);
        }
        
        // GET: ParkedVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.parkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegistrationNumber,Type,Color,Brand,Model,NoOfWheels,CheckInTime,CheckOutTime,TotalTime,ParkingPrice")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.parkedVehicles.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.parkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegistrationNumber,Type,Color,Brand,Model,NoOfWheels")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            DateTime checkout = DateTime.Now;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.parkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }

            TimeSpan totalTime = checkout - parkedVehicle.CheckInTime;

            double Initprize = 5;

            if (totalTime.Days < 1)
            {
                parkedVehicle.ParkingPrice = Initprize * totalTime.Hours;
            }

            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkedVehicle parkedVehicle = db.parkedVehicles.Find(id);
            db.parkedVehicles.Remove(parkedVehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
