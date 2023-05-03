namespace EmployeeManagement.Services.MessageBus
{
    public interface IMessageBus
    {
        void SendMessage(int employeeId, int newJobLevel);
    }
}