using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.Core
{
    [Table("DossiersAnnules")]
    public class DossierAnnule
    {

        public int IdDossier { get; set; }
        [ForeignKey("IdDossier")]
        public virtual  DossierReservation Dossier { get; set; }

        public int Id { get; set; }

        public string Nom { get; set; }
        
        public List<Voyage> Voyages { get; set; }

    }
}
