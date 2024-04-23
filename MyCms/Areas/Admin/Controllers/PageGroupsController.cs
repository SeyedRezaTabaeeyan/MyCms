using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace MyCms.Areas.Admin.Controllers
{
    public class PageGroupsController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: Admin/PageGroups
        public ActionResult Index()
        {
            return View(db.PageGroupRepository.Get());
        }

        // GET: Admin/PageGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = db.PageGroupRepository.GetById(id);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pageGroup);
        }

        // GET: Admin/PageGroups/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/PageGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,GroupTitle")] PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
                db.PageGroupRepository.Insert(pageGroup);                
                return RedirectToAction("Index");
            }

            return View(pageGroup);
        }

        // GET: Admin/PageGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = db.PageGroupRepository.GetById(id);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pageGroup);
        }

        // POST: Admin/PageGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,GroupTitle")] PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
                db.PageGroupRepository.Update(pageGroup);                
                return RedirectToAction("Index");
            }
            return View(pageGroup);
        }

        // GET: Admin/PageGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = db.PageGroupRepository.GetById(id);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pageGroup);
        }

        // POST: Admin/PageGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PageGroup pageGroup = db.PageGroupRepository.GetById(id);
            db.PageGroupRepository.Delete(pageGroup);
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
