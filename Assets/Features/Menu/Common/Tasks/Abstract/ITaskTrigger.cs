namespace Menu.Common.Tasks.Abstract
{
    public interface ITaskTrigger<T>
    {
        ITask CreateHandle();
    }
}