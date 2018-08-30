using System;
using System.Collections.Generic;
using BoVoyage.Framework.UI;
using BoVoyage.Core;

namespace BoVoyage.App
{
    public class ModuleAgences : ModuleBase<Application>
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageAgences =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<AgenceVoyage>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<AgenceVoyage>(x=>x.Nom, "Nom", 25),
            };

        private List<AgenceVoyage> liste = new List<AgenceVoyage>();

        public ModuleAgences(Application application, string nomModule)
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
            this.liste = MethodesAgence.GetAgences();
            ConsoleHelper.AfficherListe(this.liste, strategieAffichageAgences);
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau");

            var agenceVoyage = new AgenceVoyage()
            {
                Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom ?"),
            };
            MethodesAgence.CreerAgence(agenceVoyage);
        }
    }
}
