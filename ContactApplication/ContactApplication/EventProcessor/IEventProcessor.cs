namespace ContactApplication.EventProcessor
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);
    }
}
