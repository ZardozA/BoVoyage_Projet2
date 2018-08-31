using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            }
        }     
        public static void SupprimerAgence()
        {
            AgenceVoyage agence = ChoisirAgence();
            using (var contexte = new Contexte())
            {
                contexte.Entry(agence).State = EntityState.Deleted;
                contexte.SaveChanges();
            }
        }
        public static void ModifierAgence(AgenceVoyage agence)
        {                     
            using (var contexte = new Contexte())
            {
                contexte.AgencesVoyages.Attach(agence);
                contexte.Entry(agence).State = EntityState.Modified;
                contexte.SaveChanges();
            }
        }       
        public static AgenceVoyage ChoisirAgence()
        {
            Console.WriteLine("Quelle agence (Id)?");
            var idAgence = int.Parse(Console.ReadLine());

            using (var contexte = new Contexte())
            {
                return contexte.AgencesVoyages                  
                    .Single(x => x.Id == idAgence);
            }
        }

        //implementation Modification
        /*
         private void Modifier()
        {
            ConsoleHelper.AfficherEntete("Modifier une agence");
            AgenceVoyage choix = MethodesAgence.ChoisirAgence();
            
                choix.Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom ?");
            
            MethodesAgence.ModifierAgence(choix);
        } 
        */

    }
}
