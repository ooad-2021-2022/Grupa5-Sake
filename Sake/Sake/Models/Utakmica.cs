using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sake.Models
{
    public class Utakmica
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("SportskiTim")]
        public int IdDomaćina { get; set; }

        [ForeignKey("SportskiTim")]
        public int IdGosta { get; set; }

        public DateTime VrijemeOdržavanja { get; set; }

        public DateTime MjestoOdržavanja { get; set; }
    }
}
