namespace Catalog.Domain;

public class Result<TValue>
{
    public bool     IsSuccess { get; private set; }
    public bool     IsFailure => !IsSuccess;
    public TValue?  Value     { get; private set; }
    public string[] Errors    { get; private set; }

    private Result (bool isSuccess, TValue? value, params string[] errors)
    {
        IsSuccess = isSuccess;
        Value     = value;
        Errors    = errors;
    }

    public static Result<T> Success<T>(T value) => new(true, value);
    public static Result<T> Failure<T>(params string[] errors) => new(false, default, errors);
}

public static class Result
{
    public static Result<T> Success<T>(T value) => Result<T>.Success(value);
    public static Result<T> Failure<T>(params string[] errors) => Result<T>.Failure<T> (errors);
}
