using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BoVoyage.Core
{
    public class MethodesDossier
    {
        public static List<DossierReservation> GetDossiers()
        {
            using (var contexte = new Contexte())
            {
                var dossiers = contexte.DossiersReservations
                    .OrderBy(x => x.Id).ToList();
                return dossiers;
            }
        }
        public static void CreerDossier(DossierReservation dossier)
        {
            using (var contexte = new Contexte())
            {
                contexte.DossiersReservations.Add(dossier);
                contexte.SaveChanges();
            }
        }
        public void SupprimerDossier()
        {
            DossierReservation dossier = ChoisirDossier();
            using (var contexte = new Contexte())
            {
                contexte.Entry(dossier).State = EntityState.Deleted;
                contexte.SaveChanges();
            }
        }
        private static void ModifierDossier(DossierReservation dossier)
        {

            using (var contexte = new Contexte())
            {
                contexte.DossiersReservations.Attach(dossier);
                contexte.Entry(dossier).State = EntityState.Modified;
                contexte.SaveChanges();
            }
        }
        private static DossierReservation ChoisirDossier()
        {
            Console.WriteLine("Quelle dossier (Id)?");
            var idDossier = int.Parse(Console.ReadLine());

            using (var contexte = new Contexte())
            {
                return contexte.DossiersReservations
                    .Single(x => x.Id == idDossier);
            }
        }

        //implementation Modification
        /*
          private void Modifier()
        {
            ConsoleHelper.AfficherEntete("Modifier un Dossier");
            DossierReservation choix = MethodesDossier.ChoisirDossier();

            choix.NumeroCarteBancaire = ConsoleSaisie.SaisirChaineObligatoire("Numero de Carte Bancaire ?");
            choix.PrixParPersonne = ConsoleSaisie.SaisirDecimalObligatoire("Prix par personne ?");
            
            MethodesDossier.ModifierDossier(choix);
        }
        */

    }
}
