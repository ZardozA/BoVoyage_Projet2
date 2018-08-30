using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.Core
{
    [Table("AgencesVoyages")]
    public class AgenceVoyage
    {
        public int Id { get; set; }

        public string Nom { get; set; }

    }
}
