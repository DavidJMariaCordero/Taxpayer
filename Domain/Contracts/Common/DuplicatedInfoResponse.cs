using System.Globalization;
using System.Net;

namespace Domain.Contracts.Common
{
    public sealed class DuplicatedInfoResponse : AppErrorResponse
    {
        public DuplicatedInfoResponse(string infoDescription) : base(
            $"The provided info [{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(infoDescription)}] already EXISTS. Please Verify",
            new ResultStatusCode(HttpStatusCode.UnprocessableEntity, $"[{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(infoDescription)}] already EXISTS"))
        {
        }
    }

    public sealed class DuplicatedInfoResponse<T> : AppErrorResponse<T>
    {
        public DuplicatedInfoResponse(T value, string infoDescription) :
            base(value,
                $"The provided info [{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(infoDescription)}] already EXISTS. Please Verify",
                new ResultStatusCode(HttpStatusCode.UnprocessableEntity, $"[{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(infoDescription)}] already EXISTS"))
        {
        }
    }
}