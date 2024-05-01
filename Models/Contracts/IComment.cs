namespace TaskManagement.Models.Contracts
{
    public interface IComment
    {
        string Author { get; }
        string Message { get; }
    }
}
