namespace Response 
{

    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }   
        public string Message { get; set; }
        public T Data { get; set; }


        public static ApiResponse<T> Success(T data, int statusCode) 
        {
            return new ApiResponse<T>{
                Data = data,
                StatusCode = statusCode
             };
        }

        public static ApiResponse<T> Success(int statusCode)
        {
            return new ApiResponse<T>{
                StatusCode = statusCode,
            };
        } 

        public static ApiResponse<T> Fail(int statusCode, string message)
        {
            return new ApiResponse<T>{
                StatusCode = statusCode,
                Message = message
            };
        }

        public static ApiResponse<T> Fail(int statusCode)
        {
            return new ApiResponse<T>{
                StatusCode = statusCode
            };
        }

    }

}