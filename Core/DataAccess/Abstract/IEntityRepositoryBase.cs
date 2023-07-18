using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface IEntityRepositoryBase<T>
        where T : class, IEntity, new()
    {
        Task<IList<T>> GetAllAsync(IList<Expression<Func<T,bool>>> predicates = null, IList<Expression<Func<T,object>>> includes = null);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate, IList<Expression<Func<T, object>>> includes = null);
        Task<IList<T>> SearchAsync(IList<Expression<Func<T, bool>>> predicates, IList<Expression<Func<T, object>>> includes = null);
        Task<T> GetAsync(IList<Expression<Func<T, bool>>> predicates, IList<Expression<Func<T, object>>> includes = null);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, IList<Expression<Func<T, object>>> includes = null);
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(params T[] entities);
        Task<T> UpdateAsync(T entity);
        Task UpdateRangeAsync(params T[] entities);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
        IQueryable<T> GetAsQueryable();
    }
}
