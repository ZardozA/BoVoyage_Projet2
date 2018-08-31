using BoVoyage.Framework.UI;
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
        public static void SupprimerClient()
        {
            Client client = ChoisirClient();
            using (var contexte = new Contexte())
            {
                contexte.Entry(client).State = EntityState.Deleted;
                contexte.SaveChanges();
            }
        }
        public static void ModifierClient(Client client)
        {
            using (var contexte = new Contexte())
            {
                contexte.Clients.Attach(client);
                contexte.Entry(client).State = EntityState.Modified;
                contexte.SaveChanges();
            }
        }
        public static Client ChoisirClient()
        {
            AfficherClient();

            Console.WriteLine("Quel client (Id)?");

            var idClient = int.Parse(Console.ReadLine());

            using (var contexte = new Contexte())
            {
                return contexte.Clients
                    .Single(x => x.Id == idClient);
            }
        }

        public static void AfficherClient()
        {
            var liste = MethodesClient.GetClients();
            foreach (var client in liste)
            {
                Console.Write($"({client.Id}) - {client.Nom} - {client.Prenom} - {client.DateNaissance} \n");
            }
        }
}
}
