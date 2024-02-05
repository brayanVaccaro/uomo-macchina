using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Rendicontazione
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid Id { get; set; }

        public int OreTotali { get; set; }

        public DateTime Data { get; set; }

        public DateTime OraInizio { get; set; }

        public DateTime OraFine { get; set; }

        public bool Straordinario { get; set; }

        public string Commessa { get; set; }

        public string Dettagli { get; set; }
    }
}
