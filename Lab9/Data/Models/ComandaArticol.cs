namespace Proiect.Data.Models
{
    public class ComandaArticol
    {
        public Guid IdComanda { get; set; }
        public Comanda Comanda { get; set; }
        public Guid IdArticol {  get; set; }
        public Articol Articol { get; set; }
    }
}
