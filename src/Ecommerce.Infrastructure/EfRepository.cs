using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ecommerce.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure;

public abstract class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly EcommerceDbContext _context;

    public EfRepository(EcommerceDbContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public virtual void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public virtual IQueryable<TEntity> GetAll(bool asNoTracking = true)
    {
        if(asNoTracking)
            return _context.Set<TEntity>().AsNoTracking();
        else
            return _context.Set<TEntity>().AsQueryable();
    }

    public virtual IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> queryable = GetAll();
        foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
        {
            queryable = queryable.Include<TEntity, object>(includeProperty);
        }

        return queryable;
    }

    public virtual async Task<TEntity> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        _context.Update(entity);
        return;
    }
}
