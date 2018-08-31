using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.Core
{
    public class Assurance
    {
        public int Id { get; set; }

        public decimal Montant { get; set; }
     
        public byte Type { get; set; }

        public List<DossierReservation> Dossiers { get; set; }

    }
}
