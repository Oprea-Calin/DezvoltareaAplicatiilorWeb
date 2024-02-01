using Lab9.Data;
using Lab9.Repositories.GenericRepository;
using Proiect.Data.Models;

namespace Proiect.Repositories.ProvideriRepository
{
    public class ProvideriRepository: GenericRepository<Provider>, IProvideriRepository
    {
        public ProvideriRepository(ProjectContext projectContext) :base(projectContext){ }

    }
}
