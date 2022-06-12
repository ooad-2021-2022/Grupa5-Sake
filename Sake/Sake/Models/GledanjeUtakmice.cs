using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sake.Models
{
    public class GledanjeUtakmice
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Utakmica")]
        public int IdUtakmice { get; set; }

        public bool DostupanLivestream { get; set; }

    }
}
