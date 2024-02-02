using Lab9.Data;
using Lab9.Models;
using Lab9.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Proiect.Data.Models;

namespace Proiect.Repositories.ProvideriRepository
{
    public class ProvideriRepository: GenericRepository<Provider>, IProvideriRepository
    {
        public ProvideriRepository(ProjectContext projectContext) :base(projectContext){ }
        
        public async Task<Provider> GetProviderById(Guid id)
        {
            return await _projectContext.Provideri.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task UpdateAsync(Provider provider)
        {
            _projectContext.Update(provider);
            await _projectContext.SaveChangesAsync();
        }

    }
}
