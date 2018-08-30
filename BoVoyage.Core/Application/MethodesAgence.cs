using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Core.Application
{
    class MethodesAgence
    {
        public static void AfficherAgences()
        {
            Console.WriteLine();
            Console.WriteLine("> Agences");

            using (var contexte = new Contexte())
            {

                ICollection<AgenceVoyage> agences = GetAgences();
                foreach (var agence in agences)
                {
                    Console.WriteLine($"({agence.Id}) : {agence.Nom}");
                }
            }
        }

        public static ICollection<AgenceVoyage> GetAgences()
        {
            using (var contexte = new Contexte())
            {
                var agences = contexte.AgencesVoyages
                    .OrderBy(x => x.Id).ToList();
                return agences;
            }
        }
    }
}
