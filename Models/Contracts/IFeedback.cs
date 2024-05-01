namespace TaskManagement.Models.Contracts
{
    public interface IFeedback : ITask
    {
        int Rating { get; }
    }
}
