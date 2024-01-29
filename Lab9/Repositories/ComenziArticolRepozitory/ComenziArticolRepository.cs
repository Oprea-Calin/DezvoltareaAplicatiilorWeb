using Lab9.Data;
using Microsoft.EntityFrameworkCore;
using Proiect.Data.Models;

namespace Proiect.Repositories.ComenziArticolRepozitory
{
    public class ComenziArticolRepository : IComenziArticolRepository
    {
        protected readonly ProjectContext _projectContext;
        protected readonly DbSet<ComandaArticol> _table;
        public ComenziArticolRepository(ProjectContext projectContext)
        {
            this._projectContext = projectContext;
            _table = _projectContext.Set<ComandaArticol>();
        }
        public async Task CreateAsync(ComandaArticol comandaArticol)
        {
            await _projectContext.AddAsync(comandaArticol);
        }

        public async Task<bool> SaveAsync()
        {
            return await _projectContext.SaveChangesAsync()> 0;
        }
    }
}
