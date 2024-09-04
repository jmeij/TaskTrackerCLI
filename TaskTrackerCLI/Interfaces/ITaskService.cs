namespace TaskTrackerCLI.Interfaces
{
    public interface ITaskService
    {
        Task<int> AddNewTask(string description);
    }   
}
