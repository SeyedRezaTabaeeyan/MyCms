using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UnitOfWork:IDisposable
    {
        MyCmsContext db=new MyCmsContext();

        //***************************************************
        private GenericRepository<Page> _pages;
		public GenericRepository<Page> Pages
        {
			get 
			{
				if(_pages == null)
                    _pages = new GenericRepository<Page>(db);
				return _pages; 
			}			
		}

        //***************************************************
        private GenericRepository<PageGroup> _pageGroups;
		public GenericRepository<PageGroup> PageGroups
		{
			get
			{ 
				if(_pageGroups == null) 
					_pageGroups= new GenericRepository<PageGroup>(db);
				return _pageGroups; 
			}			
		}

		//***************************************************
		private GenericRepository<PageComment> _pageComments;
		public GenericRepository<PageComment> PageComments
		{
			get 
			{
				if(_pageComments == null)
					_pageComments= new GenericRepository<PageComment>(db);
				return _pageComments; 
			}
			
		}

        public void Dispose()
        {
			db.SaveChanges();
			db.Dispose();
        }
    }
}
