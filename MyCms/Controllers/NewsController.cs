using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

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

        [Route("News/{id}")]
        public ActionResult ShowNews(int id)
        {
            var page=db.PageRepository.GetById(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            
            return View(page);
        }
        
        public ActionResult AddComment(int id, string name,string email,string comment)
        {
            db.PageCommentRepository.Insert(new PageComment()
            {
                PageId= id,
                Name= name,
                Email= email,
                Comment= comment,
                CreateDate= DateTime.Now
            }); 
            return PartialView("ShowComments",db.PageCommentRepository.Get(p => p.PageId == id));
        }

        public ActionResult ShowComments(int id)
        {
            return PartialView(db.PageCommentRepository.Get(p=>p.PageId== id));
        }

    }
}