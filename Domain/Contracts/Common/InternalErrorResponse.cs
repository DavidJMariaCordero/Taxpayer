using System.Globalization;
using System.Net;

namespace Domain.Contracts.Common
{
    public sealed class InternalErrorResponse : AppErrorResponse
    {
        public InternalErrorResponse(string errorMessage) : base(
            $"{SomethingWrong}: [{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(errorMessage)}]",
            new ResultStatusCode(HttpStatusCode.InternalServerError, CultureInfo.CurrentCulture.TextInfo.ToTitleCase(errorMessage)))
        {
        }
    }

    public sealed class InternalErrorResponse<T> : AppErrorResponse<T>
    {
        public InternalErrorResponse(T value, string errorMessage) :
            base(value,
                $"{SomethingWrong}: [{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(errorMessage)}]",
                new ResultStatusCode(HttpStatusCode.InternalServerError, CultureInfo.CurrentCulture.TextInfo.ToTitleCase(errorMessage)))
        {
        }
    }
}