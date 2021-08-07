using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.Repositories;

namespace UoWRepo.Persistence.Repositories
{

    public class MemoryRepository<TEntity> : Repository<TEntity> where TEntity : Core.Domain.TEntity
    {

        protected new readonly Linq2DbContext context;
        //protected readonly Repository<TEntity> repository;

        private readonly IRepository<TEntity> repository;

        protected static IDictionary<string, IEnumerable<TEntity>> TestList = new Dictionary<string, IEnumerable<TEntity>>();
        IDictionary<string, IEnumerable<TEntity>> openWith = new Dictionary<string, IEnumerable<TEntity>>();


        public MemoryRepository(Linq2DbContext context, Repository<TEntity> repository) : base(context)
        {
            //this.MemoryContext = MemoryContext;
            this.repository = repository;
            this.context = context;

        }

        public override void Add(TEntity entity)
        {
            ResetMemory(entity);
            base.Add(entity);
        }

        public override int AddWithIdentity(TEntity entity)
        {
            ResetMemory(entity);
            return base.AddWithIdentity(entity);
        }

        public override void AddOrUpdate(Expression<Func<TEntity, bool>> predicate)
        {

            throw new NotImplementedException();
        }

        public override void AddRange(IEnumerable<TEntity> entities)
        {
            ResetMemory(entities);
            base.AddRange(entities);
        }       
     

        public override TEntity Get(int id)
        {
            var nameOfEntity = typeof(TEntity).Name;
            var result = TestList.FirstOrDefault(x => x.Key == nameOfEntity).Value;

            if (result == null)
            {
                var entity = base.Get(id);              
                return entity;
            }

            var whatIWasLooking =result.SingleOrDefault(x => x.Id == id);

            if (whatIWasLooking == null)
            {

                var entity = base.Get(id);
                return entity;
            }


            return result.SingleOrDefault(x => x.Id == id);
        }

        public override IEnumerable<TEntity> GetAll()
        {
            var nameOfEntity= typeof(TEntity).Name;
            var result = TestList.FirstOrDefault(x => x.Key == nameOfEntity).Value;

            if (result == null) 
            {
                var liste = base.GetAll();
                TestList.Add(nameOfEntity, liste.ToList());
                return liste;
            }
            return result;
        }

        public override void Remove(TEntity entity)
        {
            ResetMemory(entity);
            base.Remove(entity);
        }

        public override void RemoveRange(IEnumerable<TEntity> entities)
        {
            ResetMemory(entities);
            base.RemoveRange(entities);
        }       

        public override void Update(TEntity entity)
        {
            ResetMemory(entity);
            try
            {
                base.Update(entity);
            }
            catch (Exception e)
            {
                var mm = e.Message;
            }



        }

        protected void ResetMemory<T>(T entity)
        {
            var nameOfEntity = typeof(T).Name;
            var result = TestList.FirstOrDefault(x => x.Key == nameOfEntity).Value;

            if (result != null)
            {
                TestList.Remove(nameOfEntity);
            }
        }


        protected void ResetMemory(TEntity entity)
        {
            var nameOfEntity = typeof(TEntity).Name;
            var result = TestList.FirstOrDefault(x => x.Key == nameOfEntity).Value;

            if (result != null)
            {
                TestList.Remove(nameOfEntity);
            }
        }

        protected void ResetMemory(IEnumerable<TEntity> entities)
        {
            var nameOfEntity = typeof(TEntity).Name;
            var result = TestList.FirstOrDefault(x => x.Key == nameOfEntity).Value;

            if (result != null)
            {
                TestList.Remove(nameOfEntity);
            }
        }
    }
}
