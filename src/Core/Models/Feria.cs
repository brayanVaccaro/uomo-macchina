using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Feria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTime DataInizio { get; set; }

        public DateTime DataFine { get; set; }

        public int Durata { get; set; }

        public string Dettagli { get; set; }
    }
}
