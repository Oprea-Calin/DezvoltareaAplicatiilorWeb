using AutoMapper;
using Lab9.Data;
using Lab9.Repositories.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using Proiect.Data.DTOs;
using Proiect.Data.Models;
using Proiect.Repositories.ArticoleRepository;

namespace Proiect.Services.ArticoleService
{
    public class ArticoleService: GenericRepository<Articol>,IArticoleService
    {
        public IArticoleRepository _articoleRepository;
        public IMapper _mapper;

        public ArticoleService(IArticoleRepository articoleRepository, IMapper mapper, ProjectContext projectContext): base(projectContext)
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

        public Articol FindByName(string name)
        {
            return _table.FirstOrDefault(u => u.Denumire.Equals(name));
        }

        public async Task<Articol> DeleteArticol(string nume)
        {
            var articol = FindByName(nume);
            if (articol == null) { throw new Exception("Articol not found!"); }
            _projectContext.Articole.Remove(articol);
            await _projectContext.SaveChangesAsync();
            return articol;
        }

        public async Task Update(ArticolUpdateDTO articol)
        {
            var existingArticol = await _articoleRepository.GetArticolById(articol.Id);


            if(existingArticol == null) { throw new Exception("Articol does not exist!"); }
            else
            {
                existingArticol.Descriere=articol.Descriere;
                existingArticol.Denumire=articol.Denumire;
                existingArticol.Pret=articol.Pret;
                existingArticol.Cantitate=articol.Cantitate;
            }
            await _articoleRepository.UpdateAsync(_mapper.Map<Articol>(existingArticol));




        }
        
    }
}
