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
        public static void SupprimerVoyage()
        {
            Voyage voyage = ChoisirVoyage();
            using (var contexte = new Contexte())
            {
                contexte.Entry(voyage).State = EntityState.Deleted;
                contexte.SaveChanges();
            }
        }
        public static void ModifierVoyage(Voyage voyage)
        {

            using (var contexte = new Contexte())
            {
                contexte.Voyages.Attach(voyage);
                contexte.Entry(voyage).State = EntityState.Modified;
                contexte.SaveChanges();
            }
        }
        public static Voyage ChoisirVoyage()
        {
            Console.WriteLine("Quel Voyage (Id)?");
            var idVoyage = int.Parse(Console.ReadLine());

            using (var contexte = new Contexte())
            {
                return contexte.Voyages
                    .Single(x => x.Id == idVoyage);
            }
        }
    }
}
