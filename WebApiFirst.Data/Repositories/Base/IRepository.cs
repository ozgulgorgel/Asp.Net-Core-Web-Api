using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiFirst.Data.Repositories.Base
{
    public interface  IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        int Insert(TEntity entity);
        int Update(TEntity entity);
        int Delete(int id);
    }
}
