using System;
using System.Collections.Generic;
using BoVoyage.Framework.UI;
using BoVoyage.Core;

namespace BoVoyage.App
{
    public class ModuleAssurances : ModuleBase<Application>
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageAssurances =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Assurance>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Assurance>(x=>x.Montant, "Montant", 10),
                InformationAffichage.Creer<Assurance>(x=>x.Type, "Type", 12),
                InformationAffichage.Creer<Assurance>(x=>x.Code, "Type", 12),
            };

        private List<Assurance> liste = new List<Assurance>();

        public ModuleAssurances(Application application, string nomModule)
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

        private void Afficher(string titre)
        {
            ConsoleHelper.AfficherEntete(titre);
            this.liste = MethodesAssurance.GetAssurances();
            ConsoleHelper.AfficherListe(this.liste, strategieAffichageAssurances);
        }

        private void Afficher()
        {
            ConsoleHelper.AfficherEntete("Afficher les Assurances");
            this.liste = MethodesAssurance.GetAssurances();
            ConsoleHelper.AfficherListe(this.liste, strategieAffichageAssurances);
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouvelle Assurance");

            var assurance = new Assurance()
            {
                Montant = ConsoleSaisie.SaisirDecimalObligatoire("Montant de l'assurance ?"),
                Type = ConsoleSaisie.SaisirChaineObligatoire("Type d'Assurance ?"),
                byte[] intCode = BitConverter.GetBytes(ConsoleSaisie.SaisirEntierObligatoire("Code Assurance ?")),


                byte[] intBytes = BitConverter.GetBytes(intValue);
            Array.Reverse(intBytes);
            byte[] result = intBytes;

        };
            MethodesAssurance.CreerAssurance(assurance);
        }

        private void 

        private void Supprimer()
        {
            Afficher("Supprimer une Assurance");
            MethodesAssurance.SupprimerAssurance();

        }

        private void Modifier()
        {
            Afficher("Modifier une Assurance");

            Assurance choix = MethodesAssurance.ChoisirAssurance();

            choix.Id = ConsoleSaisie.SaisirEntierObligatoire("Quelle assurance (Id) ?");

            MethodesAssurance.ModifierAssurance(choix);

        }
    }
}
