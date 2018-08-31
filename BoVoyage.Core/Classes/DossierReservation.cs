using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.Core
{
    [Table("DossiersReservations")]
    public class DossierReservation
    {
        public int Id { get; set; }

        public string NumeroCarteBancaire { get; set; }

        public decimal PrixParPersonne { get; set; }

        [NotMapped]
        public decimal PrixTotal { get; set; }

        public int IdVoyage { get; set; }
            [ForeignKey("IdVoyage")]
            public virtual Voyage Voyage { get; set; }

        public int IdClient { get; set; }
            [ForeignKey("IdClient")]
            public virtual Client Client { get; set; }



        [NotMapped]
        public int EtatDossierReservation { get; set; }

        public virtual ICollection<Assurance> Assurances { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }

        public static void Annuler(int RaisonAnnulationDossier)
        { }
        public static void ValiderSolvabilite()
        { }
        public static void Accepter()
        { }
    }
}
