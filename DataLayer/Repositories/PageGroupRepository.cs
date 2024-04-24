using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class PageGroupRepository : GenericRepository<PageGroup>
    {
        private MyCmsContext _context;
        public PageGroupRepository(MyCmsContext db) : base(db)
        {
            _context = db;
        }
        public IEnumerable<GroupsByCountPageViewModel> GroupsByCountPage()
        {
            return _context.PageGroups.Select(g => new GroupsByCountPageViewModel()
            {
                GroupID = g.GroupId,
                GroupTitle = g.GroupTitle,
                CountPage = g.Pages.Count
            });
        }
    }
}
