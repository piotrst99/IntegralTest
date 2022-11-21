using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarManageApp.Data {
    public abstract class EfCoreRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext {
        public TEntity Add(TEntity entity) {
            throw new NotImplementedException();
        }

        public TEntity Delete(int id) {
            throw new NotImplementedException();
        }

        public TEntity Get(int id) {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll() {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity) {
            throw new NotImplementedException();
        }
    }
}
