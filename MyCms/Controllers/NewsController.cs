using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCms.Controllers
{
    public class NewsController : Controller
    {
        UnitOfWork db = new UnitOfWork();
        // GET: News
        public ActionResult ShowGroupsByCountPage()
        {
            return PartialView(db.PageGroupRepository.GroupsByCountPage());
        }
        public ActionResult ShowGroupsInMenue()
        {
            return PartialView(db.PageGroupRepository.Get());
        }
        public ActionResult TopNews()
        {
            return PartialView(db.PageRepository.TopNews());
        }
        public ActionResult Slider()
        {
            return PartialView(db.PageRepository.Get(p => p.ShowInSlider == true));
        }

        public ActionResult LastNews()
        {

            return PartialView(db.PageRepository.LastNews());
        }

        [Route("Archive")]
        public ActionResult ArchiveNews()
        {
            return View(db.PageRepository.Get());
        }

        [Route("Groups/{id}/{title}")]
        public ActionResult ShowNewsByGroup(int id,string title)
        {
            ViewBag.name=title;
            return View(db.PageRepository.Get(p=>p.GroupId==id));
        }


    }
}