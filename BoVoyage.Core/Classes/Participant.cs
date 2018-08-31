using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.Core
{
    public class Participant : Personne
    {
        public int Id { get; set; }

        public int IdDossier { get; set; }
             [ForeignKey("IdDossier")]
             public virtual DossierReservation DossierReservation { get; set; }

        public double? Reduction { get; set; }

    }
}
