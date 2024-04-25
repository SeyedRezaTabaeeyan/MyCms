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
       
    }
}