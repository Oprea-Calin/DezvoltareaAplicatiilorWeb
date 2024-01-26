using Proiect.Data.Models;

namespace Proiect.Data.DTOs
{
    public class ComandaDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public ICollection<ComandaArticol>? Articole {  get; set; }
    }
}
