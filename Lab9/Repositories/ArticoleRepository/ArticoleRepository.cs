using Lab9.Data;
using Lab9.Repositories.GenericRepository;
using Proiect.Data.Models;

namespace Proiect.Repositories.ArticoleRepository
{
    public class ArticoleRepository: GenericRepository<Articol> , IArticoleRepository
    {
        public ArticoleRepository(ProjectContext projectContext) : base(projectContext) { }
    
    

    }
}
