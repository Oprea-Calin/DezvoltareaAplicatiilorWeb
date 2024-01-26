using Lab9.Data;
using Lab9.Repositories.GenericRepository;
using Proiect.Data.Models;

namespace Proiect.Repositories.ComenziRepository
{
    public class ComenziRepository : GenericRepository<Comanda>, IComenziRepository
    {
        public ComenziRepository(ProjectContext projectContext) : base(projectContext) { }


    }
}
