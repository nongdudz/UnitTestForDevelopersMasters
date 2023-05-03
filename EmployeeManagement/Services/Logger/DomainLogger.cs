namespace EmployeeManagement.Services.Logger
{
    public class DomainLogger : IDomainLogger
    {
        private readonly ILogger _logger;

        public DomainLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void EmployeeTypeHasChanged(int employeeId, int oldType, int newType)
        {
            _logger.Info(
                $"Employee {employeeId} changed type " +
                $"from {oldType} to {newType}");
        }
    }
}