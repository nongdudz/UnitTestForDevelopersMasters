namespace EmployeeManagement.Services.MessageBus
{
    public class MessageBus : IMessageBus
    {
        private readonly IBus _bus;

        public MessageBus(IBus bus)
        {
            _bus = bus;
        }

        public void SendMessage(int employeeId, int newJobLevel)
        {
            _bus.Send("Type: EMPLOYEE JOB LEVEL CHANGED; " +
                $"Id: {employeeId}; " +
                $"NewJobLevel: {newJobLevel}");
        }
    }
}