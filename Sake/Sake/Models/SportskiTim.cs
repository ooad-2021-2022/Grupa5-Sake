using System.ComponentModel.DataAnnotations;

namespace Sake.Models
{
    public class SportskiTim
    {
        [Key]
        public int Id { get; set; }

        public string Naziv { get; set; }

    }
}
