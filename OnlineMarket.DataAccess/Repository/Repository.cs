using OnlineMarket.DataModels.DbContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.DataModels.Repository
{
    public class Repository : IRepository
    {
        OnlineMarketDbContext dbContext = new OnlineMarketDbContext();

        public IQueryable<T> GetAll<T>() where T : class
        {
            return dbContext.Set<T>().AsQueryable();
        }

        public T Add<T>(T entity) where T : class
        {
            var result = dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
            return result;
        }

        public void Update<T>(T entity) where T : class
        {
            dbContext.Entry<T>(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            dbContext.Set<T>().Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
