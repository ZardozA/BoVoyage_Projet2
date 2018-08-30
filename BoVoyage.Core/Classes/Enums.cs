using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Core.Classes
{
    public class Enums
    {
        enum TypeAssurance { Annulation = 1 };
        enum EtatDossierResevation { enAttente, enCours, refusee, acceptee };
        enum RaisonAnnulationDossier { client = 1, placesInsuffisantes };


    }
}
