using ExecutorQueries = System.Func<Poppers.Browser.Interfaces.IBrowser, object>;

namespace Poppers.Browser.Interfaces;

internal interface IExecutorQueriesQueue
{
    void Enqueue(ExecutorQueries queries);
    bool TryDequeue(out ExecutorQueries queries);
}