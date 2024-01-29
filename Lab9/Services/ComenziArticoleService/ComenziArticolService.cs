using AutoMapper;
using Lab9.Repositories.UserRepository;
using Microsoft.AspNetCore.Mvc;
using Proiect.Data.DTOs;
using Proiect.Data.Models;
using Proiect.Repositories.ArticoleRepository;
using Proiect.Repositories.ComenziArticolRepozitory;
using Proiect.Repositories.ComenziRepository;

namespace Proiect.Services.ComenziArticoleService
{
    public class ComenziArticolService : IComenziArticolService
    {
        public IUserRepository _userRepository;
        public IArticoleRepository _articoleRepository;
        public IComenziRepository _comenziRepository;
        public IComenziArticolRepository _comenziArticolRepository;

        public IMapper _mapper { get; set; }

        public ComenziArticolService(IMapper mapper, IUserRepository userRepository, IArticoleRepository articoleRepository,IComenziRepository comenziRepository, IComenziArticolRepository comenziArticolRepository)
        {
            _mapper = mapper;  
            _userRepository = userRepository;
            _articoleRepository = articoleRepository;
            _comenziRepository = comenziRepository;
            _comenziArticolRepository   = comenziArticolRepository;

        }

        public async Task AddArticolToComanda(Guid IdComanda, Guid idArticol)
        {
            var comanda = _comenziRepository.FindById(IdComanda);
            if ( comanda ==null )
            {
                new Exception("Comanda does not exist!");
            }


            var articol = await _articoleRepository.FindByIdAsync(IdComanda);
            if(articol == null )
            {
                new Exception("Articol does not exist!");
            }

            await _comenziArticolRepository.CreateAsync(_mapper.Map<ComandaArticol>(new ComandaArticolDTO() { 
                idArticol = idArticol,
                IdComanda= IdComanda
            }));
            await _comenziArticolRepository.SaveAsync();
        }



    }
}
