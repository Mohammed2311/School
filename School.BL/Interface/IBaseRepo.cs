using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.BL.Interface
{
    public interface IBaseRepo<T> where T : class
    {
       Task<T> GetById(int id, string[] includes = null);
        
        Task<T> AddAsync(T entity);
        T Update(T entity);
        Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        Task<List<T>> GetAll();
        void Delete(T entity);
        

    }
}
