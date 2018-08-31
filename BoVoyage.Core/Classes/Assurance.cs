using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.Core
{
    public class Assurance
    {
        public int Id { get; set; }

        public decimal Montant { get; set; }

        public string Type { get; set; }

        public byte Code {get;set; }


        public List<DossierReservation> Dossiers { get; set; }

    }
}
