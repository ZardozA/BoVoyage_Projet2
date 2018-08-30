using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Core
{
    public class MethodesAgence
    {
        public static List<AgenceVoyage> GetAgences()
        {
            using (var contexte = new Contexte())
            {
                var agences = contexte.AgencesVoyages
                    .OrderBy(x => x.Id).ToList();
                return agences;
            }
        }
        public static void CreerAgence(AgenceVoyage agence)
        {
            using (var contexte = new Contexte())
            {
                contexte.AgencesVoyages.Add(agence);
                contexte.SaveChanges();
                List<AgenceVoyage> liste = new List<AgenceVoyage>();
            }
        }
    }
}
