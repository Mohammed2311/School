using Microsoft.EntityFrameworkCore;
using School.BL.Interface;
using School.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.BL.Repo
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        private readonly SchoolContext context;

        public BaseRepo(SchoolContext context)
        {
            this.context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
         await context.Set<T>().AddAsync(entity);
            return entity;
        }

        public  void Delete(T entity)
        {
             context.Set<T>().Remove(entity);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = context.Set<T>();

            if (includes != null)
                foreach (var incluse in includes)
                    query = query.Include(incluse);

            return await query.SingleOrDefaultAsync(criteria);
        }

        public async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id, string[] includes = null)
        {
            var query = context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                     query.Include(item);
                }
            }
            return await query.FindAsync(id);

        }

        public T Update(T entity)
        {
             context.Set<T>().Update(entity);
            return entity;
        }
    }
}
