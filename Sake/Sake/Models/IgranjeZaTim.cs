using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sake.Models
{
    public class IgranjeZaTim
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("SportskiTim")]
        public int IdTima { get; set; }

        [ForeignKey("Igrač")]
        public int IdIgrača { get; set; }
    }
}
