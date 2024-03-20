using System.Globalization;
using System.Net;

namespace Domain.Contracts.Common
{
    public sealed class BadRequestResponse : AppErrorResponse
    {
        public BadRequestResponse(string requestName) : base($"The Request for [{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(requestName)}] is invalid", new ResultStatusCode(HttpStatusCode.BadRequest, $"[{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(requestName)}] is invalid"))
        {
        }
    }

    public sealed class BadRequestResponse<T> : AppErrorResponse<T>
    {
        public BadRequestResponse(T value, string requestName) :
            base(value,
                $"The Request for [{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(requestName)}] is invalid",
                new ResultStatusCode(HttpStatusCode.BadRequest, $"[{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(requestName)}] is invalid"))
        {
        }
    }
}