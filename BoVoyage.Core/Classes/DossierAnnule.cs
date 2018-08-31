using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.Core
{
    [Table("DossiersAnnules")]
    public class DossierAnnule
    {
        [Key]
        public int IdDossier { get; set; }
            [ForeignKey("IdDossier")]
            public virtual  DossierReservation Dossier { get; set; }

        public byte RaisonAnnulationDossier { get; set; }


    }
}
