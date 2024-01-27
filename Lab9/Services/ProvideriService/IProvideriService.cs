using Proiect.Data.DTOs;
using Proiect.Data.Models;

namespace Proiect.Services.ProvideriService
{
    public interface IProvideriService
    {
        Task AddProvider(ProviderDTO provider);
        Task<List<Provider>> GetAllP();
    }
}
