using System.Net;
using System.Text.Json;

namespace Domain.Contracts.Common
{
    public abstract class AppErrorResponse : AppResponse
    {
        protected AppErrorResponse() : base(SomethingWrong)
        {
            Errors = new List<ResultStatusCode>() { new ResultStatusCode(HttpStatusCode.InternalServerError, SomethingWrong) };
        }

        protected AppErrorResponse(string message, IList<ResultStatusCode> errors) : base(message)
        {
            Errors = errors;
        }

        protected AppErrorResponse(string message) : base(message)
        {
            Errors = new List<ResultStatusCode>() { new ResultStatusCode(HttpStatusCode.InternalServerError, message) };
        }

        protected AppErrorResponse(string message, ResultStatusCode error) : base($"{SomethingWrong}: {error.Message}")
        {
            Errors = new List<ResultStatusCode>() { error };
        }

        public override string ToString() => JsonSerializer.Serialize(this);
    }

    public abstract class AppErrorResponse<T> : AppResponse<T>
    {
        protected AppErrorResponse(T value, string message, IList<ResultStatusCode> errors) : base(value, message)
        {
            Errors = errors;
        }

        protected AppErrorResponse(T value, IList<ResultStatusCode> errors) : base(value, SomethingWrong)
        {
            Errors = errors;
        }

        protected AppErrorResponse(T value, string message, ResultStatusCode error) : base(value, $"{SomethingWrong}: {error.Message}")
        {
            Errors = new List<ResultStatusCode>() { error };
        }

        protected AppErrorResponse(T value, string message) : base(value, message)
        {
            Errors = new List<ResultStatusCode>() { new ResultStatusCode(HttpStatusCode.InternalServerError, message) };
        }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}