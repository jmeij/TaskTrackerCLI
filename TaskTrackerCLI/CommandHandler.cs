using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using TaskTrackerCLI.Models;

namespace TaskTrackerCLI
{
    internal class CommandHandler
    {
        // CommandLine colors
        const string reset = "\x1b[0m";
        const string green = "\x1b[32m";
        const string yellow = "\x1b[33m";
        const string magenta = "\x1b[35m";

        internal static void TaskMain(string command, string filePath)
        {
            bool fileExists = File.Exists(filePath);
            var jsonContent = "";
            if (fileExists)
            {
                jsonContent = File.ReadAllText(filePath);
            }
            switch (command)
            {
                case "add":
                    Console.WriteLine("Adding a task...");
                    List<PersonalTask> personalTask =
                    [
                        new PersonalTask()
                        {
                            Id = 1,
                            Title = "BEEEP",
                            Status = Status.todo
                        },
                    ];

                    string json = JsonSerializer.Serialize(personalTask);
                    File.AppendAllText(filePath, json);
                    break;
                case "update":
                    Console.WriteLine("Updating a task...");
                    break;
                case "help":
                    HelpMain();
                    break;
                case "exit":
                    Console.WriteLine($"Thank you for using {green}Task Tracker CLI{reset}!");
                    Environment.Exit(0);
                    break;
                case "":
                    Console.WriteLine("Please enter a command.");
                    break;
                default:
                    Console.WriteLine($"Invalid command. Run {green}task-cli{reset} {yellow}help{reset} for information.");
                    break;
            }
           
        }

        internal static void HelpMain()
        {
            Console.WriteLine("");
            Console.WriteLine($"{green}Task Tracker CLI{reset} Help");
            Console.WriteLine("");
            Console.WriteLine($"Usage: {green}task-cli{reset} {yellow}[command]{reset}");
            Console.WriteLine("Commands:");
            Console.WriteLine("");
            Console.WriteLine("# Adding a new task");
            Console.WriteLine($"{green}task-cli{reset} {yellow}add [title]{reset}");
            Console.WriteLine("");
            Console.WriteLine("# Updating and deleting tasks");
            Console.WriteLine($"{green}task-cli{reset} {yellow}update{reset} {magenta}[id]{reset} {yellow}[title]{reset}");
            Console.WriteLine($"{green}task-cli{reset} {yellow}delete{reset} {magenta}[id]{reset}");
            Console.WriteLine("");
            Console.WriteLine("# Exit the application");
            Console.WriteLine($"{green}task-cli{reset} {yellow}exit{reset}");
            Console.WriteLine("");
            Console.WriteLine("# Marking a task as in progress or done");
            Console.WriteLine($"{green}task-cli{reset} {yellow}mark-in-progress{reset} {magenta}[id]{reset}");
            Console.WriteLine($"{green}task-cli{reset} {yellow}mark-done{reset} {magenta}[id]{reset}");
            Console.WriteLine("");
            Console.WriteLine("# Listing all tasks");
            Console.WriteLine($"{green}task-cli{reset} {yellow}list{reset}");
            Console.WriteLine("");
            Console.WriteLine("# Listing tasks by status");
            Console.WriteLine($"{green}task-cli{reset} {yellow}list done{reset}");
            Console.WriteLine($"{green}task-cli{reset} {yellow}list todo{reset}");
            Console.WriteLine($"{green}task-cli{reset} {yellow}list in-progress{reset}");
        }
    }
}
