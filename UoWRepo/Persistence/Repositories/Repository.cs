﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqToDB;
using LinqToDB.Data;
using UoWRepo.Core.BaseDomain;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.Domain;
using UoWRepo.Core.Repositories;

namespace UoWRepo.Persistence.Repositories;


using System;
using System.Collections.Generic;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Linq2DbEntity, IBaseTEntity
{
    protected readonly Linq2DbContext context;
    private string _connectionString;

    public Repository(Linq2DbContext context)
    {
        this.context = context;
    }

    public Repository(string connectionString)
    {
        context = new Linq2DbContext(connectionString);
    }

    public Repository(string connectionString, bool onDemand = true)
    {
        context = new Linq2DbContext(connectionString);
    }

    public virtual void Add(TEntity entity)
    {
        context.Insert(entity);
    }

    public virtual int AddWithIdentity(TEntity entity)
    {
        return context.InsertWithInt32Identity(entity);
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
        return context.GetTable<TEntity>().SingleOrDefault(x => x.Id == id);
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        return context.GetTable<TEntity>().ToList();
    }
    public static readonly ContextQueue contextQueue = new ContextQueue();
    public virtual IEnumerable<TEntity> GetAllWithQueue()
    {
        /*context.Connection.StateChange += (sender, args) =>
        {
            if (args.CurrentState == System.Data.ConnectionState.Open)
            {
                contextQueue.SetContext(context);
            }
        };*/
        
        var val = contextQueue.Queue(() => context.GetTable<TEntity>().ToList()).Result;
        
        return val;
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
        context.Update(entity);
    }

    public virtual TEntity LastUpdatedRow()
    {
        return context.GetTable<TEntity>().OrderByDescending(x => x.UpdatedDate).FirstOrDefault();
    }

    public virtual void AddOrUpdate(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = context.GetTable<TEntity>().SingleOrDefault(predicate);

        if (entity == null)
        {
            entity = Activator.CreateInstance<TEntity>();
            predicate.Compile().Invoke(entity);
            context.Insert(entity);
        }
        else
        {
            predicate.Compile().Invoke(entity);
            context.Update(entity);
        }
    }
}