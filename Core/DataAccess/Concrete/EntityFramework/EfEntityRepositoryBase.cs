using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete.EntityFramework
{
    //Tracking ?
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        //#region Eski Yapi 
        //private readonly TContext _context;

        //public EfEntityRepositoryBase(TContext context)
        //{
        //    _context = context;
        //    _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        //}

        //public async Task<TEntity> AddAsync(TEntity entity)
        //{
        //    await _context.Set<TEntity>().AddAsync(entity);
        //    return entity;
        //}

        //public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return await _context.Set<TEntity>().AnyAsync(predicate);
        //}

        //public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        //{
        //    return predicate == null
        //        ? await _context.Set<TEntity>().CountAsync()
        //        : await _context.Set<TEntity>().CountAsync(predicate);
        //}

        //public async Task DeleteAsync(TEntity entity)
        //{
        //    await Task.Run(() =>
        //    {
        //        _context.Set<TEntity>().Remove(entity);
        //    });
        //}

        //public async Task<TEntity> GetAsync(IList<Expression<Func<TEntity, bool>>> predicates, IList<Expression<Func<TEntity, object>>> includes = null)
        //{
        //    IQueryable<TEntity> query = _context.Set<TEntity>();
        //    if (predicates != null && predicates.Any())
        //    {
        //        foreach (var predicate in predicates)
        //        {
        //            query = query.Where(predicate);
        //        }
        //    }
        //    if (includes != null && includes.Any())
        //    {
        //        foreach (var include in includes)
        //        {
        //            query = query.Include(include);
        //        }
        //    }

        //    return await query.AsNoTracking().SingleOrDefaultAsync();
        //}

        //public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, IList<Expression<Func<TEntity, object>>> includes = null)
        //{
        //    IQueryable<TEntity> query = _context.Set<TEntity>();
        //    if (query != null)
        //    {
        //        query = query.Where(predicate);
        //    }
        //    if (includes != null && includes.Any())
        //    {
        //        foreach (var include in includes)
        //        {
        //            query = query.Include(include);
        //        }
        //    }

        //    return await query.AsNoTracking().SingleOrDefaultAsync();
        //}


        //public async Task<IList<TEntity>> GetAllAsync(IList<Expression<Func<TEntity, bool>>> predicates = null, IList<Expression<Func<TEntity, object>>> includes = null)
        //{
        //    IQueryable<TEntity> query = _context.Set<TEntity>();
        //    if (predicates != null && predicates.Any())
        //    {
        //        foreach (var predicate in predicates)
        //        {
        //            query = query.Where(predicate);
        //        }
        //    }
        //    if (includes != null && includes.Any())
        //    {
        //        foreach (var include in includes)
        //        {
        //            query = query.Include(include);
        //        }
        //    }

        //    return await query.AsNoTracking().ToListAsync();
        //}

        //public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, IList<Expression<Func<TEntity, object>>> includes = null)
        //{
        //    IQueryable<TEntity> query = _context.Set<TEntity>();
        //    if (query != null)
        //    {
        //        query = query.Where(predicate);
        //    }
        //    if (includes != null && includes.Any())
        //    {
        //        foreach (var include in includes)
        //        {
        //            query = query.Include(include);
        //        }
        //    }

        //    return await query.AsNoTracking().ToListAsync();
        //}

        //public IQueryable<TEntity> GetAsQueryable()
        //{
        //    return _context.Set<TEntity>().AsQueryable();
        //}

        //public async Task<TEntity> UpdateAsync(TEntity entity)
        //{
        //    await Task.Run(() =>
        //    {
        //        _context.Set<TEntity>().Update(entity);
        //    });
        //    return entity;
        //}
        //#endregion

        public async Task AddRangeAsync(params TEntity[] entities)
        {
            using (var context = new TContext())
            {
                await context.AddRangeAsync(entities);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateRangeAsync(params TEntity[] entities)
        {
            using (var context = new TContext())
            {
                context.UpdateRange(entities);
                await context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                await context.Set<TEntity>().AddAsync(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().AnyAsync(predicate);
            }
        }

        public async Task<IList<TEntity>> SearchAsync(IList<Expression<Func<TEntity, bool>>> predicates, IList<Expression<Func<TEntity, object>>> includes = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();
                if (predicates.Any())
                {
                    var predicateChain = PredicateBuilder.New<TEntity>();
                    foreach (var predicate in predicates)
                    {
                        // default olarak ==> predicate 1 && predicate 2
                        // linqkit ile predicate 1 || predicate 2 yapma şansı
                        predicateChain.Or(predicate);
                    }
                    query = query.Where(predicateChain);
                }

                if (includes.Any())
                {
                    foreach (var includeProperty in includes)
                    {
                        query = query.Include(includeProperty);
                    }
                }

                return await query.AsNoTracking().ToListAsync();
            }
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            using (var context = new TContext())
            {
                return predicate == null
                    ? await context.Set<TEntity>().CountAsync()
                    : await context.Set<TEntity>().CountAsync(predicate);
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> GetAsync(IList<Expression<Func<TEntity, bool>>> predicates, IList<Expression<Func<TEntity, object>>> includes = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();
                if (predicates != null && predicates.Any())
                {
                    foreach (var predicate in predicates)
                    {
                        query = query.Where(predicate);
                    }
                }
                if (includes != null && includes.Any())
                {
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                }

                return await query.AsNoTracking().SingleOrDefaultAsync();
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, IList<Expression<Func<TEntity, object>>> includes = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();
                if (query != null)
                {
                    query = query.Where(predicate);
                }
                if (includes != null && includes.Any())
                {
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                }

                return await query.AsNoTracking().SingleOrDefaultAsync();
            }
        }


        public async Task<IList<TEntity>> GetAllAsync(IList<Expression<Func<TEntity, bool>>> predicates = null, IList<Expression<Func<TEntity, object>>> includes = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();
                if (predicates != null && predicates.Any())
                {
                    foreach (var predicate in predicates)
                    {
                        query = query.Where(predicate);
                    }
                }
                if (includes != null && includes.Any())
                {
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                }

                return await query.AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, IList<Expression<Func<TEntity, object>>> includes = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();
                if (query != null)
                {
                    query = query.Where(predicate);
                }
                if (includes != null && includes.Any())
                {
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                }

                return await query.AsNoTracking().ToListAsync();
            }

        }

        public IQueryable<TEntity> GetAsQueryable()
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().AsQueryable();
            }

        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }

        }
    }
}
