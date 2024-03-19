#nullable enable
using Domain.Contracts.Common;
using Persistence;
using System.Linq.Expressions;

namespace Domain.Contracts.Repository
{
    public interface IRepositoryBase<T>
    {
        TaxContext GetContext();
        public IQueryable<T> QueryByCondition(Expression<Func<T, bool>> expression, TaxContext context);
        Task SaveChanges(TaxContext context);
        Task<AppResponse> Create(T entity);
        Task<AppResponse> CreateRange(IReadOnlyList<T> entities);
        Task<AppResponse> Delete(T entity);
        Task<AppResponse> Update(T entity, bool autoDeleteDetails = true);
        Task<IReadOnlyList<T>> FindByCondition(Expression<Func<T, bool>> expression);
        Task<IReadOnlyList<T>> FromSql<T>(string query, params object[] parameters) where T : class;
        Task<PagedResult<T>> FindByCondition(Expression<Func<T, bool>> expression, PageRequest request);
        Task<PagedResult<T>> GetAll(PageRequest request);
        Task<T?> GetById<TId>(TId id);
        void Create(T entity, TaxContext context);
        void CreateRange(IEnumerable<T> entities, TaxContext context);
        void Delete(T entity, TaxContext context);
        void Update(T entity, TaxContext context);
    }
}