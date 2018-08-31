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
        public static void SupprimerDossier()
        {
            DossierReservation dossier = ChoisirDossier();
            using (var contexte = new Contexte())
            {
                contexte.Entry(dossier).State = EntityState.Deleted;
                contexte.SaveChanges();
            }
        }
        public static void ModifierDossier(DossierReservation dossier)
        {

            using (var contexte = new Contexte())
            {
                contexte.DossiersReservations.Attach(dossier);
                contexte.Entry(dossier).State = EntityState.Modified;
                contexte.SaveChanges();
            }
        }
        public static DossierReservation ChoisirDossier()
        {
            Console.WriteLine("Quelle dossier (Id)?");
            var idDossier = int.Parse(Console.ReadLine());

            using (var contexte = new Contexte())
            {
                return contexte.DossiersReservations
                    .Single(x => x.Id == idDossier);
            }
        }

        public static void CalculerReductionAge(DateTime date)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - date.Year;
            if (now < date.AddYears(age))
            {
                age--;
            }
            if (age<12)
            {

            }
        }

    }
}
