using System.Diagnostics;
using Serilog;

namespace Screenshots.Infrastructure.Helpers;

public class ExecutionTimeChecker : IDisposable
{
    private readonly Stopwatch _timer;

    private readonly string _name;

    public ExecutionTimeChecker(string name)
    {
        _timer = new Stopwatch();
        _name = name;
        _timer.Start();
    }

    public void Dispose()
    {
        _timer.Stop();
        Log.Debug(
            "Execution time {Time} ms of {Name} method",
            _timer.ElapsedMilliseconds,
            _name);

        GC.SuppressFinalize(this);
    }
}