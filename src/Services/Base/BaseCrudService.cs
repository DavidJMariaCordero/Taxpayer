using AutoMapper;
using Domain.Contracts.Common;
using Domain.Contracts.Repository;
using Domain.Contracts.Services;
using System.Linq.Expressions;

namespace Services.Base
{
    public abstract class BaseCrudService<TModel> : IBaseCrudService
    {
        protected IRepositoryBase<TModel> Repository;
        protected IMapper Mapper;

        protected BaseCrudService(IRepositoryBase<TModel> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public async Task<AppResponse<TCreateResponse>> Create<TCreateRequest, TCreateResponse>(TCreateRequest request)
        {
            var model = Mapper.Map<TModel>(request);
            var createResponse = await Repository.Create(model);

            TCreateResponse created = default;

            if (createResponse.Succeeded)
                created = Mapper.Map<TModel, TCreateResponse>(model);

            return createResponse.Succeeded switch
            {
                true => new AppSuccessResponse<TCreateResponse>(created, createResponse.Message),
                _ => new InternalErrorResponse<TCreateResponse>(created, createResponse.Message)
            };
        }

        public async Task<AppResponse<IReadOnlyList<TCreateResponse>>> CreateRange<TCreateRequest, TCreateResponse>(IReadOnlyList<TCreateRequest> request)
        {
            var model = Mapper.Map<IReadOnlyList<TModel>>(request);
            var createResponse = await Repository.CreateRange(model);

            IReadOnlyList<TCreateResponse> created = default;

            if (createResponse.Succeeded)
                created = Mapper.Map<IReadOnlyList<TModel>, IReadOnlyList<TCreateResponse>>(model);

            return createResponse.Succeeded switch
            {
                true => new AppSuccessResponse<IReadOnlyList<TCreateResponse>>(created, createResponse.Message),
                _ => new InternalErrorResponse<IReadOnlyList<TCreateResponse>>(created, createResponse.Message)
            };
        }

        public async Task<AppResponse> Delete<TIdType>(TIdType id)
        {
            if (id is null) return new NullInfoResponse("Id");

            var model = await Repository.GetById(id);
            if (model is null) return new IdNotFoundResponse<TIdType>(id);

            var deleteResponse = await Repository.Delete(model);

            return deleteResponse;
        }

        public async Task<AppResponse> GetById<TIdType, TGetResponse>(TIdType id)
        {
            if (id is null) return new NullInfoResponse("Id");

            var model = await Repository.GetById(id);
            if (model is null) return new IdNotFoundResponse<TIdType>(id);

            var response = Mapper.Map<TModel, TGetResponse>(model);

            return new AppSuccessResponse<TGetResponse>(response);
        }

        public async Task<AppResponse> FindByCondition<TGetResponse, T>(Expression<Func<T, bool>> expression, PageRequest request)
        {
            var data = await Repository.FindByCondition(expression as Expression<Func<TModel, bool>>, request);
            if (data.Count == 0) return new DataNotFoundResponse(typeof(TGetResponse).Name);

            var response = Mapper.Map<PagedResult<TModel>, PagedResult<TGetResponse>>(data);

            return new AppSuccessResponse<PagedResult<TGetResponse>>(response);
        }

        public async Task<AppResponse> FindByCondition<TGetResponse, T>(Expression<Func<T, bool>> expression)
        {
            var data = await Repository.FindByCondition(expression as Expression<Func<TModel, bool>>);
            if (data.Count == 0) return new DataNotFoundResponse(typeof(TGetResponse).Name);

            var response = Mapper.Map<IReadOnlyList<TModel>, IReadOnlyList<TGetResponse>>(data);

            return new AppSuccessResponse<IReadOnlyList<TGetResponse>>(response);
        }

        public async Task<AppResponse> Update<TUpdateRequest>(TUpdateRequest request, bool autoDeleteDetails = true)
        {
            if (request is null) return new NullInfoResponse("Update Request");

            var model = Mapper.Map<TUpdateRequest, TModel>(request);
            var updateResponse = await Repository.Update(model, autoDeleteDetails);

            return updateResponse;
        }

        public async Task<AppResponse> ListAll<TGetResponse>(PageRequest request)
        {
            var data = await Repository.GetAll(request);
            if (data.Count == 0) return new DataNotFoundResponse(typeof(TGetResponse).Name);
            var response = Mapper.Map<PagedResult<TModel>, PagedResult<TGetResponse>>(data);
            response.MetaData = data.MetaData;
            return new AppSuccessResponse<PagedResult<TGetResponse>>(response);
        }
    }
}