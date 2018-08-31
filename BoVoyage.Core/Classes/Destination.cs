using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.Core
{
    public class Destination
    {
        [Column("IdDestination")]
        public int Id { get; set; }

        public string Continent { get; set; }

        public string Pays { get; set; }

        public string Region { get; set; }

        public string Description { get; set; }

        public List<Voyage> Voyages { get; set; }

    }
}
