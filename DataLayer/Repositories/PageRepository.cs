using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageRepository : GenericRepository<Page>
    {
        MyCmsContext _context;
        public PageRepository(MyCmsContext context):base(context)
        {
            _context = context;
        }
        public IEnumerable<Page> TopNews(int take = 4)
        {
            return _context.Pages.OrderByDescending(p=>p.Visit).Take(take);
        }

        public IEnumerable<Page> LastNews(int take = 4)
        {
            return _context.Pages.OrderByDescending(p => p.CreaetDate).Take(take);
        }

        public IEnumerable<Page> SearchPage(string q)
        {
            return _context.Pages.Where(p=>p.Text.Contains(q)||p.ShortDescription.Contains(q)
                                           ||p.Title.Contains(q)||p.Tags.Contains(q)).Distinct();
        }

    }
}
