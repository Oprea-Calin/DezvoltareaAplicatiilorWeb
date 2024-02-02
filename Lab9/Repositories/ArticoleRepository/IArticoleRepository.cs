using Lab9.Repositories.GenericRepository;
using Proiect.Data.Models;

namespace Proiect.Repositories.ArticoleRepository
{
    public interface IArticoleRepository: IGenericRepository<Articol>
    {

        Task UpdateAsync(Articol articol);
        Task<Articol> GetArticolById(Guid id);
    }
}
