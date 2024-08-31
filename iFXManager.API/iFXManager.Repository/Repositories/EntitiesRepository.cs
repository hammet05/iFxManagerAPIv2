using iFXManager.API.Models;
using iFXManager.DAL;
using iFXManager.DAL.DTOs;
using iFXManager.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFXManager.Repository.Repositories
{
    public class EntitiesRepository : IEntities
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EntitiesRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> SaveEntityAsync(Entity entity, CancellationToken cancellationToken = default)
        {
            await _applicationDbContext.AddAsync(entity);            
            return ConfirmChanges();
        }
       
        public async Task<IEnumerable<Entity>> GetAllEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await _applicationDbContext.Entities.OrderBy(e => e.EntityName).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Entity>> GetEntityByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _applicationDbContext.Entities.Where(e=>e.Id==id).ToListAsync(cancellationToken);
        }

        public Task<bool> ExistEntity(Entity entity, CancellationToken cancellationToken = default)
        {
            var exist = false;
            if (_applicationDbContext.Entities.Any(e => e.Id == entity.Id))
            {
                exist = true;
            }
            return Task.FromResult(exist);
        }

        public bool ConfirmChanges()
        {
            return _applicationDbContext.SaveChanges() >= 0;
        }
    }
}
