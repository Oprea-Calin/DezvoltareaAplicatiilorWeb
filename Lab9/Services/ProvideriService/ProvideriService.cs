using AutoMapper;
using Lab9.Models;
using Proiect.Data.DTOs;
using Proiect.Data.Models;
using Proiect.Repositories.ProvideriRepository;

namespace Proiect.Services.ProvideriService
{
    public class ProvideriService :IProvideriService
    {
        public IProvideriRepository _provideriRepository;
        public IMapper _mapper;

    public ProvideriService(IProvideriRepository provideriRepository, IMapper mapper) {  _provideriRepository = provideriRepository; _mapper = mapper; }
    public async Task AddProvider(ProviderDTO provider)
    {
        var newProvider = new Provider
        {
            Nume = provider.Name,
            Adresa = provider.Adresa,
            CUI = provider.CUI
            //articol =provider.articol

        };
            await _provideriRepository.CreateAsync(newProvider);
            await _provideriRepository.SaveAsync();

    }

        public async Task<List<Provider>> GetAllP()
        {
            var provideri = await _provideriRepository.GetAllAsync();
            if (provideri == null) throw new Exception("No provideri found.");
            List<Provider> providers = _mapper.Map<List<Provider>>(provideri);
            return providers;

        }
    }
}

