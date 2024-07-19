namespace Example.Service.Services
{
    public class NoContent;


    public class ServiceResult<T>
    {
        public T? Data { get; set; }

        public List<string>? Errors { get; set; }

        public bool IsSuccess => Errors == null || Errors.Count == 0;


        public static ServiceResult<T> Success()
        {
            return new ServiceResult<T>
            {
                Data = default!
            };
        }

        // Create static method
        public static ServiceResult<T> Success(T data)
        {
            return new ServiceResult<T>
            {
                Data = data
            };
        }

        public static ServiceResult<T> Failure(params string[] errors)
        {
            return new ServiceResult<T>
            {
                Errors = errors.ToList()
            };
        }
    }
}