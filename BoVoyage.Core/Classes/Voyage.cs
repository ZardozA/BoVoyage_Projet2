using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.Core
{
    public class Voyage
    {
        [Column("IdVoyage")]
        public int Id { get; set; }

        public DateTime DateAller { get; set; }

        public DateTime DateRetour { get; set; }

        public int PlacesDisponibles { get; set; }

        public decimal PrixParPersonne { get; set; }

        public List<DossierReservation> Dossiers { get; set; }

        public int IdAgenceVoyage { get; set; }
            [ForeignKey("IdAgenceVoyage")]
            public virtual AgenceVoyage AgenceVoyage { get; set; }

        public int IdDestination { get; set; }
            [ForeignKey("IdDestination")]
            public virtual Destination Destination { get; set; }

        public void Reserver(int places)
        {
            this.PlacesDisponibles -= places;
            MethodesVoyage.ModifierVoyage(this);

        }
    }
}
