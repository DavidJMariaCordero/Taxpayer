namespace Domain.Contracts.Common
{
    public class AppResponse
    {
        protected const string CompletedOk = "Request Completed OK!";

        protected const string SomethingWrong = "Something Went Wrong";
        public string Message { get; set; }

        public bool Succeeded => !Errors.Any();

        public IList<ResultStatusCode> Errors { get; set; } = new List<ResultStatusCode>();


        public AppResponse(string message)
        {
            Message = message;
        }
    }

    public class AppResponse<T> : AppResponse
    {
        public T Value { get; set; }

        public AppResponse(T value, string message) : base(message)
        {
            Value = value;
        }
    }
}
