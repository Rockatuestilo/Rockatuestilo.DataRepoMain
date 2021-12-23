using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UoWRepo.Core.BaseDomain;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.Repositories;

namespace UoWRepo.Persistence.RepositoriesEf
{
    public class RepositoryEf<TEntity> : IRepository<TEntity> where TEntity : BaseTEntity
    {
        private DbSet<TEntity> entities;
        protected readonly EFContext context;

        public RepositoryEf(EFContext context)
        {
            this.context = context;
            entities = context.Set < TEntity > ();  
        }

        public virtual void Add(TEntity entity)
        {
            AddWithIdentity(entity);
        }

        public virtual int AddWithIdentity(TEntity entity)
        {
            var value = entities.Add(entity);
            context.SaveChanges();
            return value.Entity.Id;
        }

        public virtual void AddOrUpdate(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual void AddRange(IEnumerable<TEntity> entitiesList)
        {
            entities.AddRange(entitiesList);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return entities.Where(predicate).ToList();
        }

        public IQueryable<TEntity> GetAllQueryble()
        {
            return entities.AsQueryable();
        }

        public IQueryable<TEntity> FindQueryble(Expression<Func<TEntity, bool>> predicate)
        {
            return entities.Where(predicate).AsQueryable();
        }

        public virtual TEntity Get(int id)
        {
            return entities.SingleOrDefault(x => x.Id == id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            
            
            return entities.ToList();
        }

        public virtual void Remove(TEntity entity)
        {
            entities.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entitiesList)
        {
            //throw new NotImplementedException();
            //context.HashtagsNews.Where(x => entities.Select(i => i.Id).Contains(x.Id)).Delete();
            //entities.RemoveRange(entitiesList);
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return entities.SingleOrDefault(predicate);
        }

        public virtual void Update(TEntity entity)
        {
            //FIXME:
            entities.Update(entity);

            //MAYBE: context.SaveChanges();
        }

        public virtual TEntity LastUpdatedRow()
        {
            return entities.OrderByDescending(x => x.UpdatedDate).FirstOrDefault();
        }
    }
}