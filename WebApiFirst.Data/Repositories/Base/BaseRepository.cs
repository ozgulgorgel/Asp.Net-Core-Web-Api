using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiFirst.Data.Context;

namespace WebApiFirst.Data.Repositories.Base
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal readonly BookContext _context;
        public BaseRepository(BookContext context)
        {
            _context = context;    
        }
        public int Delete(int id)
        {
             var entity= _context.Find<TEntity>(id);
              _context.Remove(entity);

            return _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
           var entities= _context.Set<TEntity>().ToList();
            return entities;
        }

        public TEntity GetById(int id)
        {
            return _context.Find<TEntity>(id);
        }

        public int Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return _context.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }
    }
}
