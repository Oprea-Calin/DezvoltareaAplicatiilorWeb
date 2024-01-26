using Lab9.Models.Base;

namespace Proiect.Data.Models
{
    public class Provider: BaseEntity
    {
        public string Nume { get; set; }
        public string Adresa {  get; set; }
        public int CUI {  get; set; }
        public Articol articol { get; set; }

    }
}
