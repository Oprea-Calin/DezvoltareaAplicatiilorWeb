using Lab9.Data;
using Lab9.Models;
using Lab9.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Proiect.Data.Models;

namespace Proiect.Repositories.ArticoleRepository
{
    public class ArticoleRepository: GenericRepository<Articol> , IArticoleRepository
    {
        public ArticoleRepository(ProjectContext projectContext) : base(projectContext) { }

        public async Task UpdateAsync(Articol articol)
        {
            _projectContext.Update(articol);
            await _projectContext.SaveChangesAsync();
        }
        public async Task<Articol> GetArticolById(Guid id)
        {
            return await _projectContext.Articole.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
