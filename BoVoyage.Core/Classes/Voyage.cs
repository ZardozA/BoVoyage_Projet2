using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.Core
{
    public class Voyage
    {
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

        public static string Reserver(int places,DossierReservation dossier,Voyage voyage)
        {

            if (voyage.PlacesDisponibles - places <0)
            {
                
                dossier.EtatDossierReservation = 2;
                MethodesDossier.ModifierDossier(dossier);
                return "Plus de place, le dossier est refusé";

            }
            else
            {
                voyage.PlacesDisponibles -= places;
                MethodesVoyage.ModifierVoyage(voyage);
                DossierReservation.Accepter(dossier);
                return "Réservé";
            }

        }
    }
}
