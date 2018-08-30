using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BoVoyage.Core
{
    public class MethodesDestination
    {
        public static List<Destination> GetDestinations()
        {
            using (var contexte = new Contexte())
            {
                var destinations = contexte.Destinations
                    .OrderBy(x => x.Id).ToList();
                return destinations;
            }
        }
        public static void CreerDestination(Destination destination)
        {
            using (var contexte = new Contexte())
            {
                contexte.Destinations.Add(destination);
                contexte.SaveChanges();
            }
        }
        public void SupprimerDestination()
        {
            Destination destination = ChoisirDestination();
            using (var contexte = new Contexte())
            {
                contexte.Entry(destination).State = EntityState.Deleted;
                contexte.SaveChanges();
            }
        }
        private static void ModifierDestination(Destination destination)
        {
            using (var contexte = new Contexte())
            {
                contexte.Destinations.Attach(destination);
                contexte.Entry(destination).State = EntityState.Modified;
                contexte.SaveChanges();
            }
        }
        private static Destination ChoisirDestination()
        {
            Console.WriteLine("Quelle Destination (Id)?");
            var idDestination = int.Parse(Console.ReadLine());

            using (var contexte = new Contexte())
            {
                return contexte.Destinations
                    .Single(x => x.Id == idDestination);
            }
        }

        //implementation Modification
        /*
          private void Modifier()
        {
            ConsoleHelper.AfficherEntete("Modifier un Dossier");
            Destination choix = MethodesDestination.ChoisirDestination();

            choix.Continent = ConsoleSaisie.SaisirChaineObligatoire("Continent ?");
            choix.Pays = ConsoleSaisie.SaisirChaineObligatoire("Pays ?");
            choix.Region = ConsoleSaisie.SaisirChaineObligatoire("Region ?");
            choix.Description = ConsoleSaisie.SaisirChaineObligatoire("Description ?");


            MethodesDestination.ModifierDestination(choix);
        }
        */
        
    }
}
