public interface ITask
{
    TaskState Run();
    void Terminate();
}
