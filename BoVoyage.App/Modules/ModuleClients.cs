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

        private void Afficher()
        {
            ConsoleHelper.AfficherEntete("Afficher");
            this.liste = MethodesClient.GetClients();
            ConsoleHelper.AfficherListe(this.liste, strategieAffichageClients);
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau");

            /*Client client = new Client()
            {
                Civilite = ConsoleSaisie.SaisirChaineObligatoire("Civilité ?"),
                Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom ?"),
                Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prénom?"),
                Adresse = ConsoleSaisie.SaisirChaineObligatoire("Adresse ?"),
                Telephone = ConsoleSaisie.SaisirChaineObligatoire("Téléphone ?"),
                DateNaissance = ConsoleSaisie.SaisirDateObligatoire("Date de Naissance ?"),
                Email = ConsoleSaisie.SaisirChaineObligatoire("Email ?")),
                Reduction = ConsoleSaisie.SaisirDecimalOptionnel("Réduction ?"),
            };
            MethodesClient.CreerClient(client);*/
        }

        private void Supprimer()
        {
            ConsoleHelper.AfficherEntete("Suppression");

            Afficher();
            
        }
        private void Modifier()
        {
            ConsoleHelper.AfficherEntete("Modification");

            Afficher();

        }
    }
}
