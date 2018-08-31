using System;
using System.Collections.Generic;
using BoVoyage.Framework.UI;
using BoVoyage.Core;

namespace BoVoyage.App
{
    public class ModuleClients : ModuleBase<Application>
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageClients =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Client>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Client>(x=>x.Nom, "Nom", 25),
                InformationAffichage.Creer<Client>(x=>x.Prenom, "Prénom", 25),
                InformationAffichage.Creer<Client>(x=>x.DateNaissance, "Date de Naissance", 25),
            };

        private List<Client> liste = new List<Client>();

        public ModuleClients(Application application, string nomModule)
         : base(application, nomModule)
        {
        }

        protected override void InitialiserMenu(Menu menu)
        {
            menu.AjouterElement(new ElementMenu("1", "Afficher")
            {
                FonctionAExecuter = this.Afficher
            });
            menu.AjouterElement(new ElementMenu("2", "Créer")
            {
                FonctionAExecuter = this.Nouveau
            });
            menu.AjouterElement(new ElementMenu("3", "Modifier")
            {
                FonctionAExecuter = this.Modifier
            });
            menu.AjouterElement(new ElementMenu("4", "Supprimer")
            {
                FonctionAExecuter = this.Supprimer
            });
            menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        public void Afficher(string titre)
        {
            ConsoleHelper.AfficherEntete(titre);
            this.liste = MethodesClient.GetClients();
            ConsoleHelper.AfficherListe(this.liste, strategieAffichageClients);
        }

        private void Afficher()
        {
            ConsoleHelper.AfficherEntete("Afficher Clients");
            this.liste = MethodesClient.GetClients();
            ConsoleHelper.AfficherListe(this.liste, strategieAffichageClients);
        }

        public static void AfficherClients(string titre)
        {
            ConsoleHelper.AfficherEntete(titre);
            List <Client> liste = new List<Client>();
            liste = MethodesClient.GetClients();
            ConsoleHelper.AfficherListe(liste, strategieAffichageClients);
        }


        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau Client");

            Client client = new Client()
            {
                Civilite = ConsoleSaisie.SaisirChaineObligatoire("Civilité ?"),
                Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom ?"),
                Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prénom?"),
                Adresse = ConsoleSaisie.SaisirChaineObligatoire("Adresse ?"),
                Telephone = ConsoleSaisie.SaisirChaineObligatoire("Téléphone ?"),
                DateNaissance = ConsoleSaisie.SaisirDateObligatoire("Date de Naissance ?"),
                Email = ConsoleSaisie.SaisirChaineObligatoire("Email ?"),
            };
            MethodesClient.CreerClient(client);
        }

        private void Supprimer()
        {
            Afficher("Supprimer un client");
            MethodesClient.SupprimerClient();
        }

        private void Modifier()
        {
            Afficher("Modifier un client");

            Client choix = MethodesClient.ChoisirClient();

            choix.Civilite = ConsoleSaisie.SaisirChaineObligatoire("Civilite ?");
            choix.Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom ?");
            choix.Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prenom ?");
            choix.Adresse = ConsoleSaisie.SaisirChaineObligatoire("Adresse ?");
            choix.Telephone = ConsoleSaisie.SaisirChaineObligatoire("Telephone ?");
            choix.DateNaissance = ConsoleSaisie.SaisirDateObligatoire("DateNaissance ?");
            choix.Email = ConsoleSaisie.SaisirChaineObligatoire("Email ?");

            MethodesClient.ModifierClient(choix);
        }
    }
}
