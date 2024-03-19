using Domain.Contracts.Common;
using System.Linq.Expressions;

namespace Domain.Contracts.Services
{
    public interface IBaseCrudService
    {
        Task<AppResponse<TCreateResponse>> Create<TCreateRequest, TCreateResponse>(TCreateRequest request);
        Task<AppResponse<IReadOnlyList<TCreateResponse>>> CreateRange<TCreateRequest, TCreateResponse>(IReadOnlyList<TCreateRequest> request);
        Task<AppResponse> Delete<TIdType>(TIdType id);
        Task<AppResponse> ListAll<TGetResponse>(PageRequest request);
        Task<AppResponse> GetById<TIdType, TGetResponse>(TIdType id);
        Task<AppResponse> FindByCondition<TGetResponse, T>(Expression<Func<T, bool>> expression);
        Task<AppResponse> FindByCondition<TGetResponse, T>(Expression<Func<T, bool>> expression, PageRequest request);
        Task<AppResponse> Update<TUpdateRequest>(TUpdateRequest request, bool autoDeleteDetails = true);
    }
}