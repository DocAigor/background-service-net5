using Quartz;
using System;
using System.Threading.Tasks;

[DisallowConcurrentExecution]
public class HelloJob : IJob
{
    private readonly IHelloWorld _helloWorld;

    public HelloJob(IHelloWorld helloWorld)
    {
        _helloWorld = helloWorld;
    }

    Task IJob.Execute(IJobExecutionContext context)
    {
        var result = _helloWorld.Hello();
        Console.WriteLine(result);
        return Task.CompletedTask;
    }
}
