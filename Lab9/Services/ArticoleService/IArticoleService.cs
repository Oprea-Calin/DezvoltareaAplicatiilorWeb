using Proiect.Data.DTOs;
using Proiect.Data.Models;

namespace Proiect.Services.ArticoleService
{
    public interface IArticoleService
    {
        Task AddArticol(ArticolDTO articol);
        Task<List<Articol>> GetAllAsync();
        Articol FindByName(string name);

        Task<Articol> DeleteArticol(string nume);
        Task Update(ArticolUpdateDTO articol);
    }
}
