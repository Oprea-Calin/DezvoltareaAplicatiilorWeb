using AutoMapper;
using Lab9.Data;
using Lab9.Repositories.GenericRepository;
using Proiect.Data.DTOs;
using Proiect.Data.Models;
using Proiect.Repositories.ArticoleRepository;
using Proiect.Repositories.ComenziRepository;
using System.Linq;

namespace Proiect.Services.ComenziService
{
    public class ComenziService: GenericRepository<Comanda>, IComenziService
    {
        public IComenziRepository _comenziRepository;
        public IMapper _mapper;

        public ComenziService(IComenziRepository comenziRepository, IMapper mapper, ProjectContext projectContext):base(projectContext) {
            _comenziRepository = comenziRepository;
            _mapper = mapper;   
        }
        public async Task<List<Comanda>> GetAllC()
        {
            var comenzi = await _comenziRepository.GetAllAsync();
            List<Comanda> comands = _mapper.Map<List<Comanda>>(comenzi);
            return comands;
        }
        public async Task AddComanda(ComandaDTO comanda)
        {

             var newComanda = _mapper.Map<Comanda>(comanda);


            // var newcomanda = new Comanda
            {
            //   Id = comanda.Id,
           //   Email = comanda.Email,
                
             //ComandaArticole = comanda.Articole
               
            };

            await _comenziRepository.CreateAsync(newComanda);
            await _comenziRepository.SaveAsync();
        }

        public Comanda FindById(Guid Id)
        {
            return _table.FirstOrDefault(u => u.Id.Equals(Id));
        }
        public async Task<Comanda> DeleteComanda(Guid Id)
        {
            var comanda = FindById(Id);
            if (comanda == null) throw new Exception("Comanda not found");

            _projectContext.Comenzi.Remove(comanda); 
            await _projectContext.SaveChangesAsync();
            return comanda;
        }


    }
}
