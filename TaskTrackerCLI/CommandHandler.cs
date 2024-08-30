using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace TaskTrackerCLI
{
    internal class CommandHandler
    {
        internal static void TaskMain(String command)
        {
            switch(command)
            {
                case "add":
                    Console.WriteLine("Adding a task...");
                    break;
                case "update":
                    Console.WriteLine("Updating a task...");
                    break;
                case "help":
                    HelpMain();
                    break;
                case "exit":
                    Console.WriteLine("Thank you for using \u001b[32mTask Tracker CLI\u001b[0m!");
                    Environment.Exit(0);
                    break;
                case "":
                    Console.WriteLine("Please enter a command.");
                    break;
                default:
                    Console.WriteLine("Invalid command. Run \u001b[32mtask-cli\x1b[0m \x1b[33mhelp\u001b[0m for information.");
                    break;
            }
           
        }

        internal static void HelpMain()
        {
            Console.WriteLine("");
            Console.WriteLine("Task Tracker CLI");
            Console.WriteLine("Usage: task-cli [command]");
            Console.WriteLine("Commands:");
            Console.WriteLine("");
            Console.WriteLine("# Adding a new task");
            Console.WriteLine("\u001b[32mtask-cli\u001b[0m \u001b[33madd [title]\u001b[0m");
            Console.WriteLine("");
            Console.WriteLine("# Updating and deleting tasks");
            Console.WriteLine("\u001b[32mtask-cli\u001b[0m \u001b[33mupdate\u001b[0m \u001b[35m[id]\u001b[0m \u001b[33m[title]\u001b[0m");
            Console.WriteLine("\u001b[32mtask-cli\u001b[0m \u001b[33mdelete\u001b[0m \u001b[35m[id]\u001b[0m");
            Console.WriteLine("");
            Console.WriteLine("# Exit the application");
            Console.WriteLine("\u001b[32mtask-cli\u001b[0m \u001b[33mexit\u001b[0m");
            Console.WriteLine("");
            Console.WriteLine("# Marking a task as in progress or done");
            Console.WriteLine("\u001b[32mtask-cli\u001b[0m \u001b[33mmark-in-progress\u001b[0m \u001b[35m[id]\u001b[0m");
            Console.WriteLine("\u001b[32mtask-cli\u001b[0m \u001b[33mmark-done\u001b[0m \u001b[35m[id]\u001b[0m");
            Console.WriteLine("");
            Console.WriteLine("# Listing all tasks");
            Console.WriteLine("\u001b[32mtask-cli\u001b[0m \u001b[33mlist\u001b[0m");
            Console.WriteLine("");
            Console.WriteLine("# Listing tasks by status");
            Console.WriteLine("\u001b[32mtask-cli\u001b[0m \u001b[33mlist done\u001b[0m");
            Console.WriteLine("\u001b[32mtask-cli\u001b[0m \u001b[33mlist todo\u001b[0m");
            Console.WriteLine("\u001b[32mtask-cli\u001b[0m \u001b[33mlist in-progress\u001b[0m");
        }
    }
}
