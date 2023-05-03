using EmployeeManagement.Model;

namespace EmployeeManagement.Services
{
    public interface IPromotionService
    {
        Task<Result> PromoteInternalEmployeeAsync(InternalEmployee employee);
    }
}