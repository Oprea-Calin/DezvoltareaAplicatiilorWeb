using Microsoft.AspNetCore.Mvc;
using Proiect.Data.DTOs;

namespace Proiect.Services.ComenziArticoleService
{
    public interface IComenziArticolService
    {
        Task AddArticolToComanda(Guid IdComanda, Guid idComanda);
    }
}
