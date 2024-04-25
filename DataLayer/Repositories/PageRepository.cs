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
    }
}
