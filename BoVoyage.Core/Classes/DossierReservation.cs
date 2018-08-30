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

        public int EtatDossierReservation { get; set; }

        public static void Annuler(int RaisonAnnulationDossier)
        { }
        public static void ValiderSolvabilite()
        { }
        public static void Accepter()
        { }
    }
}
