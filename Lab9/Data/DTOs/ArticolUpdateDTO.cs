namespace Proiect.Data.DTOs
{
    public class ArticolUpdateDTO
    {
        public Guid Id { get; set; }
        public string Denumire { get; set; }

        public string Descriere { get; set; }
        public int Pret { get; set; }
        public int Cantitate { get; set; }
    }
}
