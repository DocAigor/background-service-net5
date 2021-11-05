using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using JokeService.Common;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddScoped<IHelloWorld, HelloWorld>();
        services.AddHttpClient<IJokeClient, JokeClient>();

        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionScopedJobFactory();

            q.AddJob<JokeJob>(opts => opts.WithIdentity("JokeJob"))
            .AddTrigger(opts => opts
                .ForJob("JokeJob")
                .WithCronSchedule("0/5 * * * * ?"));

            q.AddJob<HelloJob>(opts => opts.WithIdentity("HelloJob"))
            .AddTrigger(opts => opts
                .ForJob("HelloJob")
                .WithCronSchedule("0/30 * * * * ?"));
        });
        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

    })
    .Build();

await host.RunAsync();

