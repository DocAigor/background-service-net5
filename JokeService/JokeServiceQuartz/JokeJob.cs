using JokeService.Common;
using Quartz;
using System;
using System.Threading.Tasks;

[DisallowConcurrentExecution]
public class JokeJob : IJob
{
    private readonly IJokeClient _jokeClient;

    public JokeJob(IJokeClient jokeClient)
    {
        _jokeClient = jokeClient;
    }

    async Task IJob.Execute(IJobExecutionContext context)
    {
        var result = await _jokeClient.GetJokeAsync();
        Console.WriteLine(result);
    }
}
