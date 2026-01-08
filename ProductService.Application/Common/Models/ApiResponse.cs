namespace ProductService.Application.Common.Models
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; init; }
        public string Message { get; init; } = string.Empty;
        public bool IsSuccess { get; init; }
        public T? Data { get; init; }

        private ApiResponse(int statusCode, string message, bool isSuccess, T? data = default)
        {
            StatusCode = statusCode;
            Message = message;
            IsSuccess = isSuccess;
            Data = data;
        }

        public static ApiResponse<T> Success(T data, string message = "Success", int statusCode = 200) =>
            new(statusCode, message, true, data);

        public static ApiResponse<T> Fail(string message = "An error occurred", int statusCode = 400) =>
            new(statusCode, message, false);

        public static ApiResponse<T> FromException(Exception ex, int statusCode = 500) =>
            new(statusCode, ex.Message, false);
    }
}
