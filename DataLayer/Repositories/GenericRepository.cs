using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class GenericRepository<TEntity> where TEntity:class 
    {
        private MyCmsContext _context;
        private DbSet<TEntity> _dbSet;
        public GenericRepository(MyCmsContext db)
        {
            _context = db;
            _dbSet= db.Set<TEntity>();
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual List<TEntity> Get(Expression<Func<TEntity,bool>> where=null,string includes="")
        {
            IQueryable<TEntity> query = _dbSet;
            if (where != null) query=query.Where(where);            
            if(includes!="")
                foreach (string include in includes.Split(','))
                {
                    query = query.Include(include);
                }
            return query.ToList();
        }

        public virtual bool Insert(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public virtual bool Update(TEntity entity) 
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public virtual bool Delete(TEntity entity) 
        {
            try
            {
                _context.Entry(entity).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public virtual void Delete(object id)
        {
            Delete(GetById(id));
        }
    }
}
