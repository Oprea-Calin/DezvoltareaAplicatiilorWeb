using Proiect.Data.Models;

namespace Proiect.Data.DTOs
{
    public class ArticolDTO
    {
        public Guid Id { get; set; }
        public string Denumire { get; set; }

        public string Descriere {  get; set; }
        public int Pret { get; set; }
        public int Cantitate {  get; set; }
        //public Provider Provider { get; set; }
    }
}
