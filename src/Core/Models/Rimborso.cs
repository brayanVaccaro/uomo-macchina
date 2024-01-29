using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Rimborso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid Id { get; set; }

        public int Importo { get; set; }

        public DateTime Data { get; set; }

        public string Commessa { get; set; }

        public string CartaAziendale { get; set; }

        public string Dettagli { get; set; }
    }
}
