using Proiect.Data.Models;

namespace Proiect.Repositories.ComenziArticolRepozitory
{
    public interface IComenziArticolRepository
    {
        Task CreateAsync(ComandaArticol comandaArticol);
        Task<bool> SaveAsync();

    }
}
