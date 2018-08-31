using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.Core
{
    public class Client : Personne
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public List<DossierReservation> Dossiers { get; set; }

    }
}
