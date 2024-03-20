namespace Domain.Contracts.Common
{
    public sealed class AppSuccessResponse : AppResponse
    {
        public AppSuccessResponse() : base(CompletedOk)
        {
        }

        public AppSuccessResponse(string message) : base(message)
        {
        }
    }

    public sealed class AppSuccessResponse<T> : AppResponse<T>
    {
        public AppSuccessResponse(T value) : base(value, CompletedOk)
        {
            Value = value;
        }

        public AppSuccessResponse(T value, string message) : base(value, message)
        {
        }
    }
}