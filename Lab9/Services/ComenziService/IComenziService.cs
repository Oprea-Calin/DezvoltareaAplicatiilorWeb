using Microsoft.AspNetCore.Mvc;
using Proiect.Data.DTOs;
using Proiect.Data.Models;

namespace Proiect.Services.ComenziService
{
    public interface IComenziService
    {
        public Task AddComanda(ComandaDTO comanda);
        public Task<List<Comanda>> GetAllC();

    }
}
