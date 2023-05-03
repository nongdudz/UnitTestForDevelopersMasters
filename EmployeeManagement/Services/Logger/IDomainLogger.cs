namespace EmployeeManagement.Services.Logger
{
    public interface IDomainLogger
    {
        void EmployeeTypeHasChanged(int employeeId, int oldType, int newType);
    }
}