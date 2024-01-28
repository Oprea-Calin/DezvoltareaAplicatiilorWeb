using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect.Data.Models
{
    
    public class ComandaArticol
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      //  public Guid Id { get; set; }

        public Guid? IdComanda { get; set; }
        public Comanda Comanda { get; set; }


        public Guid? IdArticol {  get; set; }
        public Articol Articol { get; set; }
    }
}
