using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaskTrackerCLI.Interfaces;
using TaskTrackerCLI.Models;

namespace TaskTrackerCLI.Services
{
    internal class TaskService : ITaskService
    {
        private static readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "personalTasks.json");
        private static bool fileExists = File.Exists(filePath);

        const string reset = "\x1b[0m";
        const string green = "\x1b[32m";
        const string yellow = "\x1b[33m";
        const string magenta = "\x1b[35m";

        public Task<int> AddNewTask(string description)
        {
            Console.WriteLine("Adding a task...");
            PersonalTask personalTask = new()
            {
                Id = getLatestId(),
                Title = description,
                Status = Status.todo
            };

            if (!File.Exists(filePath))
            {
                List<PersonalTask> tasks = [];
                tasks.Add(personalTask);
                string json = JsonSerializer.Serialize(tasks);
                File.WriteAllText(filePath, json);
                fileExists = true;
            }
            else
            {
                var file = File.ReadAllText(filePath);
                var tasks = JsonSerializer.Deserialize<List<PersonalTask>>(file) ?? [];
                tasks.Add(personalTask);
                string json = JsonSerializer.Serialize(tasks);
                File.WriteAllText(filePath, json);
            }

            return Task.FromResult(personalTask.Id);
        }

        private int getLatestId()
        {
            if (!fileExists)
            {
                return 1;
            }
            else
            {
                var jsonContent = File.ReadAllText(filePath);
                var tasks = JsonSerializer.Deserialize<List<PersonalTask>>(jsonContent) ?? [];
                return tasks.Select(x => x.Id).Max() + 1;
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

        //internal void Command()
        //{
        //    switch (command)
        //    {
        //        case "add":
        //            taskService.AddNewTask();
        //            break;
        //        case "update":
        //            Console.WriteLine("Updating a task...");
        //            break;
        //        case "help":
        //            HelpMain();
        //            break;
        //        case "exit":
        //            Console.WriteLine($"Thank you for using {green}Task Tracker CLI{reset}!");
        //            Environment.Exit(0);
        //            break;
        //        case "":
        //            Console.WriteLine("Please enter a command.");
        //            break;
        //        default:
        //            Console.WriteLine($"Invalid command. Run {green}task-cli{reset} {yellow}help{reset} for information.");
        //            break;
        //    }
        //}
    }
}
