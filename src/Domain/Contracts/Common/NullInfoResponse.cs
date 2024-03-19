using System.Globalization;
using System.Net;

namespace Domain.Contracts.Common
{
    public sealed class NullInfoResponse : AppErrorResponse
    {
        public NullInfoResponse(string infoName) : base(
            $"The provided info for [{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(infoName)}] is NULL or invalid. Please Verify",
            new ResultStatusCode(HttpStatusCode.UnprocessableEntity, $"[{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(infoName)}] is NULL or invalid"))
        {
        }
    }

    public sealed class NullInfoResponse<T> : AppErrorResponse<T>
    {
        public NullInfoResponse(T value, string infoName) :
            base(value,
                $"The provided info for [{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(infoName)}] is NULL or invalid. Please Verify",
                new ResultStatusCode(HttpStatusCode.UnprocessableEntity, $"[{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(infoName)}] is NULL or invalid"))
        {
        }
    }
}