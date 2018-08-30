using System;
using System.Collections.Generic;
using BoVoyage.Framework.UI;

namespace BoVoyage.Core
{
    public class ModuleAgences : ModuleBase<Application>
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageAgences =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<AgenceVoyage>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<AgenceVoyage>(x=>x.Nom, "Nom", 10),
                InformationAffichage.Creer<AgenceVoyage>(x=>x.Prenom, "Prenom", 10),
                InformationAffichage.Creer<AgenceVoyage>(x=>x.Email, "Email", 15),
                InformationAffichage.Creer<AgenceVoyage>(x=>x.DateInscription, "Date", 10),
            };

        private readonly List<AgenceVoyage> liste = new List<AgenceVoyage>();

        public ModuleAgences(Application application, string nomModule)
            : base(application, nomModule)
        {
            this.liste = new List<AgenceVoyage>
            {
                new AgenceVoyage{Id = 1, Nom = "BAZAN", Prenom = "Yannick", DateInscription = new DateTime(2010,1,1),Email = "ybazan.pro@live.fr" },
                new AgenceVoyage{Id = 2, Nom = "PEANT", Prenom = "Frédéric", Email = "f.peant@gtm-ingenierie.fr" },
            };
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
                FonctionAExecuter = this.Nouveau
            });
            menu.AjouterElement(new ElementMenu("4", "Supprimer")
            {
                FonctionAExecuter = this.Nouveau
            });
            menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        private void Afficher()
        {
            ConsoleHelper.AfficherEntete("Afficher");

            ConsoleHelper.AfficherListe(this.liste, strategieAffichageClients);
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau");

            var client = new Client
            {
                Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom ?"),
                Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prénom ?"),
                Email = ConsoleSaisie.SaisirChaineOptionnelle("Email ?"),
                DateInscription = ConsoleSaisie.SaisirDateOptionnelle("Date d'inscription ?")
            };

            this.liste.Add(client);
        }*/
    }
}
