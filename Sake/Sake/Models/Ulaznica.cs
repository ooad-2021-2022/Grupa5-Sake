using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sake.Models
{
    public class Ulaznica
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Utakmica")]
        public int IdUtakmice { get; set; }

        [ForeignKey("GledanjeUtakmice")]
        public int IdGledanja { get; set; }

        public double Cijena { get; set; }

        public bool Dostupna { get; set; }

    }
}
