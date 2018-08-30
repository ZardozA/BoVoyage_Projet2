using System;
using System.Collections.Generic;
using BoVoyage.Framework.UI;
using BoVoyage.Core;

namespace BoVoyage.App
{
    public class ModuleVoyages : ModuleBase<Application>
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageVoyages =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Voyage>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Voyage>(x=>x.DateAller, "Date Aller", 12),
                InformationAffichage.Creer<Voyage>(x=>x.DateRetour, "Date Retour", 12),
                InformationAffichage.Creer<Voyage>(x=>x.PlacesDisponibles, "Places Disponibles", 5),
                InformationAffichage.Creer<Voyage>(x=>x.PrixParPersonne, "Prix par personne", 8),
            };

        private List<Voyage> liste = new List<Voyage>();

        public ModuleVoyages(Application application, string nomModule)
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
            this.liste = MethodesVoyage.GetVoyages();
            ConsoleHelper.AfficherListe(this.liste, strategieAffichageVoyages);
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau");

            var voyage = new Voyage()
            {
                DateAller = ConsoleSaisie.SaisirDateObligatoire("Date Aller ?"),
                DateRetour = ConsoleSaisie.SaisirDateObligatoire("Date Retour ?"),
                PlacesDisponibles = ConsoleSaisie.SaisirEntierObligatoire("Places Disponibles ?"),
                PrixParPersonne = ConsoleSaisie.SaisirDecimalObligatoire("Nom ?"),
            };
            MethodesVoyage.CreerVoyage(voyage);
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
