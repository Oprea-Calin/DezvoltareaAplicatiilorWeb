using Proiect.Data.DTOs;

namespace Proiect.Services.ArticoleService
{
    public interface IArticoleService
    {
        Task AddArticol(ArticolDTO articol);
    }
}
