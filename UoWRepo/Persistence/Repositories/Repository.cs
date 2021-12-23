using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.Repositories;
using LinqToDB;
using LinqToDB.Data;

namespace UoWRepo.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Core.Domain.TEntity
    {
        protected readonly Linq2DbContext context;
        private IRepository<TEntity> _repositoryImplementation;

        public Repository(Linq2DbContext context)
        {
            this.context = context;
        }

        public virtual void Add(TEntity entity)
        {
            context.BeginTransaction();
            context.Insert(entity);
        }

        public virtual int AddWithIdentity(TEntity entity)
        {
            context.BeginTransaction();
            return context.InsertWithInt32Identity(entity);
        }

        public virtual void AddOrUpdate(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            context.BulkCopy(entities);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context.GetTable<TEntity>().Where(predicate).ToList();
        }

      
        public virtual IQueryable<TEntity> FindQueryble(Expression<Func<TEntity, bool>> predicate)
        {
            return context.GetTable<TEntity>().Where(predicate).AsQueryable();
        }

        public virtual TEntity Get(int id)
        {
            return context.GetTable<TEntity>().SingleOrDefault(x =>x.Id == id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return context.GetTable<TEntity>().ToList();
        }
        public virtual IQueryable<TEntity> GetAllQueryble()
        {
            return context.GetTable<TEntity>().AsQueryable();
        }


        public virtual void Remove(TEntity entity)
        {
            context.Delete(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            context.HashtagsNews.Where(x => entities.Select(i => i.Id).Contains(x.Id)).Delete();
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return context.GetTable<TEntity>().SingleOrDefault(predicate);
        }

        public virtual void Update(TEntity entity)
        {
            context.BeginTransaction();
            context.Update(entity);
        }

        public virtual TEntity LastUpdatedRow()
        {
            return context.GetTable<TEntity>().OrderByDescending(x => x.UpdatedDate).FirstOrDefault();
        }  
    }   
}
