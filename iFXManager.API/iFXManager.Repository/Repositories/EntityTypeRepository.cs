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
    public class EntityTypeRepository : IEntityTypes
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EntityTypeRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<EntityType>> GetAllEntityTypesAsync(CancellationToken cancellationToken = default)
        {
            return await _applicationDbContext.EntityTypes.OrderBy(p => p.Description).Where(p => p.Status == true).ToListAsync(cancellationToken);
        }
    }
}
