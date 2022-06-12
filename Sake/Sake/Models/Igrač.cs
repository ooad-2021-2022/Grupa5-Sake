using System;
using System.ComponentModel.DataAnnotations;

namespace Sake.Models
{
    public class Igrač
    {
        [Key]
        public int Id { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public DateTime DatumRođenja { get; set; }

    }
}
