using Microsoft.Extensions.DependencyInjection;
using TaskTrackerCLI.Interfaces;
using TaskTrackerCLI.Services;

namespace TaskTrackerCLI
{
    internal class Program
    {
        public static void Main(string[] args)
        {

        var serviceProvider = new ServiceCollection()
                .AddSingleton<ICommandService>(new CommandService())
                .AddSingleton<ITaskService>(new TaskService())
                .BuildServiceProvider();
        
        var commandService = serviceProvider.GetService<ICommandService>() ?? throw new Exception("Command service is null.");
        commandService.HandleCommand(args);
        }   
    }
}
