using QuickBuy.Domain.Contract;
using QuickBuy.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Repository.Repositories
{
  public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
  {
    protected readonly QuickBuyContext QuickBuyContext;

    public RepositoryBase(QuickBuyContext quickBuyContext)
    {
      QuickBuyContext = quickBuyContext;
    }

    public void Add(TEntity entity)
    {
      QuickBuyContext.Set<TEntity>().Add(entity);
      QuickBuyContext.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
      QuickBuyContext.Set<TEntity>().Update(entity);
      QuickBuyContext.SaveChanges();
    }

    public IEnumerable<TEntity> GetAll()
    {
      return QuickBuyContext.Set<TEntity>().ToList();
    }

    public TEntity GetById(int id)
    {
      return QuickBuyContext.Set<TEntity>().Find(id);
    }

    public void Update(TEntity entity)
    {
      QuickBuyContext.Set<TEntity>().Remove(entity);
      QuickBuyContext.SaveChanges();
    }

    public void Dispose()
    {
      QuickBuyContext.Dispose();
    }

  }
}
