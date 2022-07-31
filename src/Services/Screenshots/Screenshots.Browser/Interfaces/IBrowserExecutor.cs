namespace Screenshots.Browser.Interfaces;

public interface IBrowserExecutor
{
    T Execute<T>(Func<IBrowser, T> callback);

    Task<T> ExecuteAsync<T>(Func<IBrowser, T> callback);

    Task<T> ExecuteAsync<T>(Func<IBrowser, Task<T>> callback);
}