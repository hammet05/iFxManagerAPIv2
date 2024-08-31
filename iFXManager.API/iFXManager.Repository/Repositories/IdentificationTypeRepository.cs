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
    public class IdentificationTypeRepository : IIdentificationTypes
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public IdentificationTypeRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<IdentificationType>> GetAllIdentificationTypesAsync(CancellationToken cancellationToken = default)
        {
            return await _applicationDbContext.IdentificationTypes.OrderBy(p => p.Description).Where(p => p.Status == true).ToListAsync(cancellationToken);
        }
    }
}
