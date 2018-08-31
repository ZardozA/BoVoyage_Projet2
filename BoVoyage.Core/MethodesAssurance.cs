using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BoVoyage.Core
{
    public class MethodesAssurance
    {
        public static List<Assurance> GetAssurances()
        {
            using (var contexte = new Contexte())
            {
                var assurances = contexte.Assurances
                    .OrderBy(x => x.Id).ToList();
                return assurances;
            }
        }
        public static void CreerAssurance(Assurance assurance)
        {         
            using (var contexte = new Contexte())
            {
                contexte.Assurances.Add(assurance);
                contexte.SaveChanges();
            }
        }
        public static Assurance ChoisirAssurance()
        {
            Console.WriteLine("Quelle Assurance (Id)?");
            var idAssurance = int.Parse(Console.ReadLine());

            using (var contexte = new Contexte())
            {
                return contexte.Assurances
                    .Single(x => x.Id == idAssurance);
            }
        }
        public static void ModifierAssurance(Assurance assurance)
        {          
            using (var contexte = new Contexte())
            {
                contexte.Assurances.Attach(assurance);
                contexte.Entry(assurance).State = EntityState.Modified;
                contexte.SaveChanges();
            }
        }
        public static void SupprimerAssurance()
        {
            Assurance assurance = ChoisirAssurance();
            using (var contexte = new Contexte())
            {
                contexte.Entry(assurance).State = EntityState.Deleted;
                contexte.SaveChanges();
            }
        }
    }
}
