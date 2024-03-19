using System.Net;

namespace Domain.Contracts.Common
{
    public sealed class IdNotFoundResponse<TIdType> : AppErrorResponse
    {
        public IdNotFoundResponse(TIdType id) : base(
            $"The requested id [{id}] was NOT found or is invalid. Please Verify",
            new ResultStatusCode(HttpStatusCode.NotFound, $"Id [{id}] NOT found or invalid"))
        {
        }
    }

    public sealed class IdNotFoundResponse<TIdType, T> : AppErrorResponse<T>
    {
        public IdNotFoundResponse(TIdType id, T value) :
            base(value,
                $"The requested id [{id}] was NOT found or is invalid. Please Verify",
                new ResultStatusCode(HttpStatusCode.NotFound, $"Id [{id}] NOT found or invalid"))
        {
        }
    }
}