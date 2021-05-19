using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RuilwinkelVaals.Models;

namespace RuilwinkelVaals.Controllers
{
    public class ProfileDatasController : Controller
    {
        private UserDataModel db = new UserDataModel();

        // GET: ProfileDatas
        public ActionResult Index()
        {
            var profileData = db.ProfileData.Include(p => p.AccountData).Include(p => p.AccountType_LT).Include(p => p.Ledenpas_LT);
            return View(profileData.ToList());
        }

        // GET: ProfileDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileData profileData = db.ProfileData.Find(id);
            if (profileData == null)
            {
                return HttpNotFound();
            }
            return View(profileData);
        }

        // GET: ProfileDatas/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.AccountData, "Id", "Hash");
            ViewBag.AccountType = new SelectList(db.AccountType_LT, "Id", "AccountType");
            ViewBag.Ledenpas = new SelectList(db.Ledenpas_LT, "Id", "Status");
            return View();
        }

        // POST: ProfileDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Voornaam,Achternaam,Balans,AccountType,Ledenpas,Straat,Huisnummer,Woonplaats,Postcode,Geboortedatum,DateCreated")] ProfileData profileData)
        {
            if (ModelState.IsValid)
            {
                db.ProfileData.Add(profileData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.AccountData, "Id", "Hash", profileData.Id);
            ViewBag.AccountType = new SelectList(db.AccountType_LT, "Id", "AccountType", profileData.AccountType);
            ViewBag.Ledenpas = new SelectList(db.Ledenpas_LT, "Id", "Status", profileData.Ledenpas);
            return View(profileData);
        }

        // GET: ProfileDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileData profileData = db.ProfileData.Find(id);
            if (profileData == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.AccountData, "Id", "Hash", profileData.Id);
            ViewBag.AccountType = new SelectList(db.AccountType_LT, "Id", "AccountType", profileData.AccountType);
            ViewBag.Ledenpas = new SelectList(db.Ledenpas_LT, "Id", "Status", profileData.Ledenpas);
            return View(profileData);
        }

        // POST: ProfileDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Voornaam,Achternaam,Balans,AccountType,Ledenpas,Straat,Huisnummer,Woonplaats,Postcode,Geboortedatum,DateCreated")] ProfileData profileData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profileData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.AccountData, "Id", "Hash", profileData.Id);
            ViewBag.AccountType = new SelectList(db.AccountType_LT, "Id", "AccountType", profileData.AccountType);
            ViewBag.Ledenpas = new SelectList(db.Ledenpas_LT, "Id", "Status", profileData.Ledenpas);
            return View(profileData);
        }

        // GET: ProfileDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileData profileData = db.ProfileData.Find(id);
            if (profileData == null)
            {
                return HttpNotFound();
            }
            return View(profileData);
        }

        // POST: ProfileDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProfileData profileData = db.ProfileData.Find(id);
            db.ProfileData.Remove(profileData);
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
