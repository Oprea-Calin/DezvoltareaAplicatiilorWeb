﻿using AutoMapper;
using Proiect.Data.DTOs;
using Proiect.Data.Models;
using Proiect.Repositories.ArticoleRepository;
using Proiect.Repositories.ComenziRepository;

namespace Proiect.Services.ComenziService
{
    public class ComenziService: IComenziService
    {
        public IComenziRepository _comenziRepository;
        public IArticoleRepository _articoleRepository;
        public IMapper _mapper;

        public ComenziService(IComenziRepository comenziRepository, IMapper mapper, IArticoleRepository articole) {
            _comenziRepository = comenziRepository;
            _mapper = mapper;   
            _articoleRepository = articole;
        }
        public async Task<List<ComandaDTO>> GetAllC()
        {
            var comenzi = await _comenziRepository.GetAllAsync();
            return _mapper.Map<List<ComandaDTO>>(comenzi);
        }
        public async Task AddComanda(ComandaDTO comanda)
        {

            var newComanda = _mapper.Map<Comanda>(comanda);


            //var newcomanda = new Comanda
            //{
             //   Id = comanda.Id,
              //  Email = comanda.Email,
               // comandaArticole = comanda.Articole

            //};

            await _comenziRepository.CreateAsync(newComanda);
            await _comenziRepository.SaveAsync();
        }
    }
}
