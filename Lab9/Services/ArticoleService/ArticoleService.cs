using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proiect.Data.DTOs;
using Proiect.Data.Models;
using Proiect.Repositories.ArticoleRepository;

namespace Proiect.Services.ArticoleService
{
    public class ArticoleService: IArticoleService
    {
        public IArticoleRepository _articoleRepository;
        public IMapper _mapper;

        public ArticoleService(IArticoleRepository articoleRepository, IMapper mapper)
        {
            _articoleRepository = articoleRepository;
            _mapper = mapper;
        }
        public async Task AddArticol(ArticolDTO articol)
        {
            var newArt = new Articol
            {
                Id = articol.Id,
                Denumire = articol.Denumire,
                Descriere = articol.Descriere,
                Pret = articol.Pret,
                Cantitate = articol.Cantitate,
                Provider = articol.Provider

            };
            await _articoleRepository.CreateAsync(newArt);
            await _articoleRepository.SaveAsync();
        }
    }
}
