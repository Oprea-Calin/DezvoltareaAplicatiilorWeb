﻿using Lab9.Repositories.GenericRepository;
using Proiect.Data.DTOs;
using Proiect.Data.Models;

namespace Proiect.Repositories.ProvideriRepository
{
    public interface IProvideriRepository: IGenericRepository<Provider>
    {
        Task<Provider> GetProviderById(Guid id);
        Task UpdateAsync(Provider provider);
    }
}
