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
            var newArticol = _mapper.Map<Articol>(articol);
            await _articoleRepository.CreateAsync(newArticol);
            await _articoleRepository.SaveAsync();
        }

        public async Task<List<Articol>> GetAllAsync()
        {
            var articole = await _articoleRepository.GetAllAsync();
            List<Articol> articols = _mapper.Map<List<Articol>>(articole);
            return articols;
        }

        
    }
}
