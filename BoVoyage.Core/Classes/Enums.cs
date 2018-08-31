using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Core
{
    public class Enums
    {
        public enum TypeAssurance { Annulation = 1 };

        public enum EtatDossierResevation { enAttente, enCours, refusee, acceptee };

        public enum RaisonAnnulationDossier { client = 1, placesInsuffisantes };


    }
}
