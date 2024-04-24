using DataLayer.Repositories;
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
        private GenericRepository<Page> _pageRepository;
		public GenericRepository<Page> PageRepository
        {
			get 
			{
				if(_pageRepository == null)
                    _pageRepository = new GenericRepository<Page>(db);
				return _pageRepository; 
			}			
		}

        //***************************************************
        private PageGroupRepository _pageGroupRepository;
		public PageGroupRepository PageGroupRepository
        {
			get
			{ 
				if(_pageGroupRepository == null)
                    _pageGroupRepository = new PageGroupRepository(db);
				return _pageGroupRepository; 
			}			
		}

		//***************************************************
		private GenericRepository<PageComment> _pageCommentRepository;
		public GenericRepository<PageComment> PageCommentRepository
        {
			get 
			{
				if(_pageCommentRepository == null)
                    _pageCommentRepository = new GenericRepository<PageComment>(db);
				return _pageCommentRepository; 
			}
			
		}

        public void Dispose()
        {
			db.SaveChanges();
			db.Dispose();
        }
    }
}
