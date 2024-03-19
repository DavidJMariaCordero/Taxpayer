using Domain.Contracts.Common;
using Domain.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using System.Linq.Expressions;

namespace Repository.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly IServiceScopeFactory _scopeFactory;

        protected RepositoryBase(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public void Create(T entity, TaxContext context) => context.Set<T>().Add(entity);

        public async Task<AppResponse> Create(T entity)
        {
            await using var context = GetContext();
            Create(entity, context);
            _ = await context.SaveChangesAsync();
            return new AppSuccessResponse<string>($"{entity.GetType().Name} Created Ok!");
        }

        public void CreateRange(IEnumerable<T> entities, TaxContext context) => context.Set<T>().AddRangeAsync(entities);

        public async Task<AppResponse> CreateRange(IReadOnlyList<T> entities)
        {
            await using var context = GetContext();
            CreateRange(entities, context);
            _ = await context.SaveChangesAsync();
            return new AppSuccessResponse<string>($"{entities.GetType().Name} Created Ok!");
        }

        public void Delete(T entity, TaxContext context) => context.Set<T>().Remove(entity);

        public async Task<AppResponse> Delete(T entity)
        {
            await using var context = GetContext();
            Delete(entity, context);
            _ = await context.SaveChangesAsync();
            return new AppSuccessResponse<string>($"{entity.GetType().Name} Deleted Ok!");
        }

        public async Task<PagedResult<T>> FindByCondition(Expression<Func<T, bool>> expression, PageRequest request)
        {
            await using var context = GetContext();
            var data = QueryByCondition(expression, context);
            return await PagedResult<T>.ToPagedResult(data, request.PageNumber, request.PageSize);
        }

        public async Task<IReadOnlyList<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            await using var context = GetContext();
            var data = QueryByCondition(expression, context);
            return await data.ToListAsync();
        }

        public IQueryable<T> QueryByCondition(Expression<Func<T, bool>> expression, TaxContext context)
        {
            return context.Set<T>()
                .Where(expression)
                .AsNoTracking();
        }

        public async Task<PagedResult<T>> GetAll(PageRequest request)
        {
            await using var context = GetContext();
            var data = context.Set<T>().AsNoTracking();
            return await PagedResult<T>.ToPagedResult(data, request.PageNumber, request.PageSize);
        }

        public virtual async Task<T?> GetById<TIdType>(TIdType id)
        {
            await using var context = GetContext();
            return await context.Set<T>().FindAsync(id);
        }

        public TaxContext GetContext()
        {
            var scope = _scopeFactory.CreateScope();
            var scopeContext = scope.ServiceProvider.GetRequiredService<TaxContext>();
            return scopeContext;
        }

        public async Task SaveChanges(TaxContext context) => await context.SaveChangesAsync();

        public void Update(T entity, TaxContext context) => context.Set<T>().Update(entity);

        public async Task<AppResponse> Update(T entity, bool autoDeleteDetails = true)
        {
            await using var context = GetContext();
            Update(entity, context);
            _ = await context.SaveChangesAsync();
            return new AppSuccessResponse<string>($"{entity.GetType().Name} Updated Ok!");
        }

        public async Task<IReadOnlyList<T>> FromSql<T>(string query, params object[] parameters) where T : class
        {
            await using var context = GetContext();
            return await context.Set<T>().FromSqlRaw(query, parameters).ToListAsync();
        }
    }
}