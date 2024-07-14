using System.Text.Json.Serialization;

namespace WebAndAPI.Razor.Services;

public class ServiceResult<T>
{
    public T? Data { get; set; }


    public List<string>? Errors { get; set; }

    public bool IsSuccess => Errors is null || Errors?.Count > 0;
    public bool IsFailure => Errors is not null || Errors?.Count > 0;

    public static ServiceResult<T> Success(T data) => new ServiceResult<T> { Data = data };

    public static ServiceResult<T> Failure(params string[] errors) => new ServiceResult<T> { Errors = errors.ToList() };

    public static ServiceResult<T> Failure(IEnumerable<string> errors) =>
        new ServiceResult<T> { Errors = errors.ToList() };
}

public class ServiceResult
{
    public List<string>? Errors { get; set; }


    public bool IsSuccess => Errors?.Count == 0;


    public static ServiceResult Failure(params string[] errors) => new ServiceResult { Errors = errors.ToList() };

    public static ServiceResult Failure(IEnumerable<string> errors) => new ServiceResult { Errors = errors.ToList() };
}