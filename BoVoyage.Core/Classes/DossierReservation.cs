using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.Core
{
    [Table("DossiersReservations")]
    public class DossierReservation
    {
        public int Id { get; set; }

        public string NumeroCarteBancaire { get; set; }

        public decimal PrixParPersonne { get; set; }

        public decimal PrixTotal { get; set; }

        public int IdVoyage { get; set; }
        [ForeignKey("IdVoyage")]
        public virtual Voyage Voyage { get; set; }

        public int IdClient { get; set; }
        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }

        public int IdParticipant { get; set; }
        [ForeignKey("IdParticipant")]
        public virtual Participant Participant { get; set; }

        public int IdAssurance { get; set; }
        [ForeignKey("IdAssurance ")]
        public virtual Assurance Assurance { get; set; }

        public int EtatDossierReservation { get; set; }

        public static void Annuler(int RaisonAnnulationDossier)
        { }
        public static void ValiderSolvabilite()
        { }
        public static void Accepter()
        { }
    }
}
