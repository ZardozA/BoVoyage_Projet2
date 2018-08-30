using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BoVoyage.Core
{
    public class MethodesVoyage
    {
        public static List<Voyage> GetVoyages()
        {
            using (var contexte = new Contexte())
            {
                var voyages = contexte.Voyages
                    .OrderBy(x => x.Id).ToList();
                return voyages;
            }
        }
        public static void CreerVoyage(Voyage voyage)
        {

            using (var contexte = new Contexte())
            {
                contexte.Voyages.Add(voyage);
                contexte.SaveChanges();
            }
        }
        public void SupprimerVoyage()
        {
            Voyage voyage = ChoisirVoyage();
            using (var contexte = new Contexte())
            {
                contexte.Entry(voyage).State = EntityState.Deleted;
                contexte.SaveChanges();
            }
        }
        private static void ModifierVoyage(Voyage voyage)
        {

            using (var contexte = new Contexte())
            {
                contexte.Voyages.Attach(voyage);
                contexte.Entry(voyage).State = EntityState.Modified;
                contexte.SaveChanges();
            }
        }
        private static Voyage ChoisirVoyage()
        {
            Console.WriteLine("Quelle Voyage (Id)?");
            var idVoyage = int.Parse(Console.ReadLine());

            using (var contexte = new Contexte())
            {
                return contexte.Voyages
                    .Single(x => x.Id == idVoyage);
            }
        }

        //implementation Modification
        /*
          private void Modifier()
        {
            ConsoleHelper.AfficherEntete("Modifier un Voyage");
            Voyage choix = MethodesVoyage.ChoisirVoyage();

            choix.DateAller = ConsoleSaisie.SaisirDateObligatoire("Date Aller ?");
            choix.DateRetour = ConsoleSaisie.SaisirDateObligatoire("Date Aller ?");
            choix.PlacesDisponibles = ConsoleSaisie.SaisirEntierObligatoire("Places Disponibles ?");
            choix.PrixParPersonne = ConsoleSaisie.SaisirDecimalObligatoire("Prix par personne ?");
            choix.AgenceVoyage = ConsoleSaisie.SaisirChaineObligatoire("Nom de l'agence ?");
            choix.Destination = ConsoleSaisie.SaisirChaineObligatoire("Destination ?");

            MethodesVoyage.ModifierVoyage(choix);
        }
        */

    }
}
