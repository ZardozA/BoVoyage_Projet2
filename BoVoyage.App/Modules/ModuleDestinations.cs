using System;
using System.Collections.Generic;
using BoVoyage.Framework.UI;
using BoVoyage.Core;

namespace BoVoyage.App
{
    public class ModuleDestinations : ModuleBase<Application>
    {
        private static readonly List<InformationAffichage> strategieAffichageDestinations =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Destination>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Destination>(x=>x.Continent, "Continent", 25),
                InformationAffichage.Creer<Destination>(x=>x.Pays, "Pays", 25),
                InformationAffichage.Creer<Destination>(x=>x.Region, "Région", 25),
                InformationAffichage.Creer<Destination>(x=>x.Description, "Description", 50),
              
            };

        private List<Destination> liste = new List<Destination>();

        public ModuleDestinations(Application application, string nomModule)
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
            this.liste = MethodesDestination.GetDestinations();
            ConsoleHelper.AfficherListe(this.liste, strategieAffichageDestinations);
        }

        private void Afficher()
        {
            ConsoleHelper.AfficherEntete("Afficher");
            this.liste = MethodesDestination.GetDestinations();
            ConsoleHelper.AfficherListe(this.liste, strategieAffichageDestinations);
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau");

            Destination destination = new Destination()
            {              
                Continent = ConsoleSaisie.SaisirChaineObligatoire("Continent ?"),             
                Pays = ConsoleSaisie.SaisirChaineObligatoire("Pays ?"),             
                Region= ConsoleSaisie.SaisirChaineObligatoire("Region ?"),             
                Description = ConsoleSaisie.SaisirChaineObligatoire("Description ?"),             
            };
            MethodesDestination.CreerDestination(destination);
        }

        private void Supprimer()
        {
            Afficher("Supprimer une Destination");
            MethodesDestination.SupprimerDestination();
        }

        private void Modifier()
        {
            Afficher("Modifier une Destination");

            Destination choix = MethodesDestination.ChoisirDestination();
          
            choix.Id = ConsoleSaisie.SaisirEntierObligatoire("Quelle destination (Id) ?");

            MethodesDestination.ModifierDestination(choix);
        }
    }
 
}
