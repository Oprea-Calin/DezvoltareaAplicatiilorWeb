using Lab9.Models.Base;

namespace Proiect.Data.Models
{
    public class Articol: BaseEntity
    {
        public string Denumire {  get; set; }

        public string Descriere {  get; set; }
        public int Pret {  get; set; }
        public int Cantitate {  get; set; }
        public Provider Provider { get; set; }
        public ICollection<ComandaArticol> comandaArticole {  get; set; }

    }
}
