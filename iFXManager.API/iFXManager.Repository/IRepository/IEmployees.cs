using iFXManager.API.Models;
using iFXManager.DAL.Models;

namespace iFXManager.Repository.IRepository
{
    public interface IEmployees
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync(CancellationToken cancellationToken = default);

        Task<IEnumerable<Employee>> GetEmployeesByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> ExistEmployee(Employee employee, CancellationToken cancellationToken = default);

        Task<bool> SaveEmployeesAsync(Employee employee, CancellationToken cancellationToken = default);

        bool ConfirmChanges();
    }
}
