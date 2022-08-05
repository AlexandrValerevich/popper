namespace Screenshots.Browser.Interfaces;

internal interface IBrowserExecutor
{
    void Execute(Action<IBrowser> callback);

    Task ExecuteAsync(Func<IBrowser, Task> callback, CancellationToken token);
}