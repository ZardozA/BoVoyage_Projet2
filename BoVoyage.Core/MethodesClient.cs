using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BoVoyage.Core
{
    public class MethodesClient
    {
        public static List<Client> GetClients()
        {
            using (var contexte = new Contexte())
            {
                var clients = contexte.Clients
                    .OrderBy(x => x.Id).ToList();
                return clients;
            }
        }
        public static void CreerClient(Client client)
        {
            using (var contexte = new Contexte())
            {
                contexte.Clients.Add(client);
                contexte.SaveChanges();
            }
        }
        public void SupprimerClient()
        {
            Client client = ChoisirClient();
            using (var contexte = new Contexte())
            {
                contexte.Entry(client).State = EntityState.Deleted;
                contexte.SaveChanges();
            }
        }
        private static void ModifierClient(Client client)
        {
            using (var contexte = new Contexte())
            {
                contexte.Clients.Attach(client);
                contexte.Entry(client).State = EntityState.Modified;
                contexte.SaveChanges();
            }
        }
        private static Client ChoisirClient()
        {
            Console.WriteLine("Quelle Client (Id)?");
            var idClient = int.Parse(Console.ReadLine());

            using (var contexte = new Contexte())
            {
                return contexte.Clients
                    .Single(x => x.Id == idClient);
            }
        }

        //implementation Modification
        /*
          private void Modifier()
        {
            ConsoleHelper.AfficherEntete("Modifier un Dossier");
            Client choix = MethodesClient.ChoisirClient();

            choix.Civilite = ConsoleSaisie.SaisirChaineObligatoire("Civilite ?");
            choix.Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom ?");
            choix.Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prenom ?");
            choix.Adresse = ConsoleSaisie.SaisirChaineObligatoire("Adresse ?");
            choix.Telephone = ConsoleSaisie.SaisirChaineObligatoire("Telephone ?");
            choix.DateNaissance = ConsoleSaisie.SaisirDateObligatoire("DateNaissance ?");
            choix.Email = ConsoleSaisie.SaisirChaineObligatoire("Telephone ?");

            MethodesClient.ModifierClient(choix);
        }
        */

    }
}
