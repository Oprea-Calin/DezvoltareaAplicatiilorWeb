using Lab9.Models;
using Lab9.Models.Base;

namespace Proiect.Data.Models
{
    public class Comanda : BaseEntity
    {
        public string Email {  get; set; }
        public User User { get; set; }
        public ICollection<ComandaArticol> comandaArticole {  get; set; }
    }
}
