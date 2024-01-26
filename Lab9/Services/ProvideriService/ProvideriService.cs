using Proiect.Data.DTOs;
using Proiect.Data.Models;
using Proiect.Repositories.ProvideriRepository;

namespace Proiect.Services.ProvideriService
{
    public class ProvideriService :IProvideriService
    {
        public IProvideriRepository _provideriRepository;

    public ProvideriService(IProvideriRepository provideriRepository) {  _provideriRepository = provideriRepository; }
    public async Task AddProvider(ProviderDTO provider)
    {
        var newProvider = new Provider
        {
            Nume = provider.Name,
            Adresa = provider.Adresa,
            CUI = provider.CUI,
            articol =provider.articol

        };
            await _provideriRepository.CreateAsync(newProvider);
            await _provideriRepository.SaveAsync();

    }
    }
}

