using TaskTrackerCLI.Interfaces;
using TaskTrackerCLI.Models;

namespace TaskTrackerCLI.Services
{
    internal class CommandService : ICommandService
    {
        public void HandleCommand(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Welcome to \u001b[32mTask Tracker CLI\u001b[0m!");
                Console.WriteLine("Please enter the command:");

                do
                {
                    Console.Write("> "); // Display prompt
                    var command = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(command))
                    {
                        var commandParams = command.Split(' ');
                        if (commandParams.Length > 3)
                        {
                            Console.WriteLine("Invalid command. Please try again.");
                            return;
                        }
                        switch (commandParams[0])
                        {
                            case "add":
                                if (commandParams.Length == 2)
                                {
                                    var description = commandParams[1];
                                    var taskService = new TaskService();
                                    var addedTask = taskService.AddNewTask(description);
                                    if (addedTask != null && addedTask.Result != 0)
                                    {
                                        Console.WriteLine($"Task added with ID: {addedTask.Result}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Failed to add task. Please try again.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a description for the task.");
                                }
                                break;
                            default:
                                Console.WriteLine("Invalid command. Please try again.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Command cannot be empty. Please try again.");
                    }
                }
                while (true);
            }
        }
    }
}
