using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sake.Models
{
    public class Lutrija
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AspNetUsers")]
        public int IdKorisnika { get; set; }

        [ForeignKey("Utakmica")]
        public int IdUtakmice { get; set; }

        [ForeignKey("Utakmica")]
        public int IdPobjednika { get; set; }

        public int NagradniBodovi { get; set; }

    }
}
