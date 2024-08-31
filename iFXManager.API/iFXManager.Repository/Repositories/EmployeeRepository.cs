using iFXManager.API.Models;
using iFXManager.DAL;
using iFXManager.DAL.Models;
using iFXManager.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFXManager.Repository.Repositories
{

    public class EmployeeRepository : IEmployees
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> SaveEmployeesAsync(Employee employee, CancellationToken cancellationToken = default)
        {
            await _applicationDbContext.AddAsync(employee);
            return ConfirmChanges();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync(CancellationToken cancellationToken = default)
        {
            return await _applicationDbContext.Employees.OrderBy(e => e.FullName).ToListAsync(cancellationToken);
        }
        
        public Task<bool> ExistEmployee(Employee employee, CancellationToken cancellationToken = default)
        {
            var exist = false;
            if (_applicationDbContext.Employees.Any(e => e.IdentificationNumber == employee.IdentificationNumber))
            {
                exist = true;
            }
            return Task.FromResult(exist);
        }
       
        public async Task<IEnumerable<Employee>> GetEmployeesByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _applicationDbContext.Employees.Where(e => e.Id == id).ToListAsync(cancellationToken);
        }

        public bool ConfirmChanges()
        {
            return _applicationDbContext.SaveChanges() >= 0;
        }


    }
}
