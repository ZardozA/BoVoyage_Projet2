using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.Core
{
    [Table("AssurancesDossiers")]
    public class AssuranceDossier
    {
        [Key, Column(Order =1)]
        public int IdDossier { get; set; }
            [ForeignKey("IdDossier")]
            public virtual DossierReservation DossierReservation { get; set; }

        [Key, Column(Order =0)]
        public int IdAssurance { get; set; }
            [ForeignKey("IdAssurance")]
            public virtual Assurance Assurance { get; set; }
    }
}
