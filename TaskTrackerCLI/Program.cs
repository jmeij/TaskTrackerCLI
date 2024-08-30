namespace TaskTrackerCLI
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Welcome to \u001b[32mTask Tracker CLI\u001b[0m!");
            Console.WriteLine("Please enter the command:");
            string command = Console.ReadLine() ?? string.Empty;
            do
            {
                CommandHandler.TaskMain(command);
                command = Console.ReadLine() ?? string.Empty;
            }
            while (true);
        }
    }
}
