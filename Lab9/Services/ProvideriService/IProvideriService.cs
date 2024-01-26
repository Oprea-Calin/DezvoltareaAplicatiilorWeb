using Proiect.Data.DTOs;

namespace Proiect.Services.ProvideriService
{
    public interface IProvideriService
    {
        Task AddProvider(ProviderDTO provider);
    }
}
