using Microsoft.AspNetCore.Mvc;
using Proiect.Data.DTOs;

namespace Proiect.Services.ComenziService
{
    public interface IComenziService
    {
        public Task AddComanda(ComandaDTO comanda);
        public Task<List<ComandaDTO>> GetAllC();

    }
}
