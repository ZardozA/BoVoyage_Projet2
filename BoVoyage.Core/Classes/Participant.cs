using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.Core
{
    public class Participant :Personne
    {
        [Column("IdParticipant")]
        public int Id { get; set; }

        public double? Reduction { get; set; }

    }
}
