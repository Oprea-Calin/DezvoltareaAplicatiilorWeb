using AutoMapper;
using Lab9.Data;
using Lab9.Models;
using Lab9.Repositories.GenericRepository;
using Proiect.Data.DTOs;
using Proiect.Data.Models;
using Proiect.Repositories.ProvideriRepository;

namespace Proiect.Services.ProvideriService
{
    public class ProvideriService : GenericRepository<Provider>,IProvideriService
    {
        public IProvideriRepository _provideriRepository;
        public IMapper _mapper;

    public ProvideriService(IProvideriRepository provideriRepository, IMapper mapper, ProjectContext projectContext): base(projectContext) 
        {  
            _provideriRepository = provideriRepository; 
            _mapper = mapper; 
        }
    public async Task AddProvider(ProviderDTO provider)
    {
            var newProvider = _mapper.Map<Provider>(provider);
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

        public Provider FindByName(string name)
        {
            return _table.FirstOrDefault(u => u.Nume.Equals(name));
        }

        public async Task<Provider> DeleteProvider(string name)
        {
            var provider = FindByName(name);
            if (provider == null) throw new Exception("User not found");

            _projectContext.Provideri.Remove(provider);
            await _projectContext.SaveChangesAsync();
            return provider;
        }

        public async Task Update(UpdateProviderDTo provider)
        {
            var existingProvider = await _provideriRepository.GetProviderById(provider.Id);
            if (existingProvider == null) throw new Exception("Provider not found!");
            else
            {
                existingProvider.CUI = provider.CUI;
                existingProvider.Nume = provider.Nume;
                existingProvider.Adresa = provider.Adresa;
            }
            await _provideriRepository.UpdateAsync(_mapper.Map<Provider>(existingProvider));

        }
    }
}

