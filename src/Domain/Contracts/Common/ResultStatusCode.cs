using System.Net;

namespace Domain.Contracts.Common
{
    public class ResultStatusCode
    {
        public HttpStatusCode Code { get; set; }

        public string Message { get; set; }

        public ResultStatusCode(HttpStatusCode code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
