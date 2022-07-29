using Microsoft.AspNetCore.Mvc;

namespace Poppers.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ThreadInfoController : ControllerBase
{

    [HttpGet]
    public ThreadCount Get()
    {
        ThreadCount threadCount = new();
        ThreadPool.GetMinThreads(out int workerThreads, out int completionPortThreads);
        threadCount.MinWorkerThreads = workerThreads;
        threadCount.MinCompletionPortThreads = completionPortThreads;

        ThreadPool.GetMaxThreads(out workerThreads, out completionPortThreads);
        threadCount.MaxWorkerThreads = workerThreads;
        threadCount.MaxCompletionPortThreads = completionPortThreads;

        return threadCount;
    }
}

public class ThreadCount
{
    public int MinWorkerThreads { get; set; }
    public int MinCompletionPortThreads { get; set; }
    public int MaxWorkerThreads { get; set; }
    public int MaxCompletionPortThreads { get; set; }
}