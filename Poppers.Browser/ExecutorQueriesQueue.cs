using System.Collections.Concurrent;
using Poppers.Browser.Interfaces;

using ExecutorQueries = System.Func<Poppers.Browser.Interfaces.IBrowser, object>;

namespace Poppers.Browser;

internal class ExecutorQueriesQueue : IExecutorQueriesQueue
{
    private readonly ConcurrentQueue<ExecutorQueries> _queue = new();

    public void Enqueue(ExecutorQueries queries)
    {
        _queue.Enqueue(queries);
    }

    public bool TryDequeue(out ExecutorQueries queries)
    {
        return _queue.TryDequeue(out queries);
    }
}