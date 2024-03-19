using System.Globalization;
using System.Net;

namespace Domain.Contracts.Common
{
    public sealed class DataNotFoundResponse : AppErrorResponse
    {
        public DataNotFoundResponse(string dataName) : base(
            $"The requested data for [{dataName}] was NOT found",
            new ResultStatusCode(HttpStatusCode.NotFound, $"[{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dataName)}] NOT found"))
        {
        }
    }

    public sealed class DataNotFoundResponse<T> : AppErrorResponse<T>
    {
        public DataNotFoundResponse(T value, string dataName) :
            base(value,
                $"The requested data for [{dataName}] was NOT found",
                new ResultStatusCode(HttpStatusCode.NotFound, $"[{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dataName)}] NOT found"))
        {
        }
    }
}