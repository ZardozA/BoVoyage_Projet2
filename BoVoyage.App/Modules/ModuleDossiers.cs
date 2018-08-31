using System;
using System.Collections.Generic;
using BoVoyage.Framework.UI;
using BoVoyage.Core;

namespace BoVoyage.App
{
    public class ModuleDossiers : ModuleBase<Application>
    {
        private static readonly List<InformationAffichage> strategieAffichageDossiers =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<DossierReservation>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<DossierReservation>(x=>x.NumeroCarteBancaire, "Numero de Carte Bancaire", 20),
                InformationAffichage.Creer<DossierReservation>(x=>x.PrixParPersonne, "Prix par personne", 20),
                InformationAffichage.Creer<DossierReservation>(x=>x.Client.Id, "Id Client", 3),
                

            };

        private List<DossierReservation> liste = new List<DossierReservation>();

        public ModuleDossiers(Application application, string nomModule)
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
            this.liste = MethodesDossier.GetDossiers();
            ConsoleHelper.AfficherListe(this.liste, strategieAffichageDossiers);
        }

        private void Afficher()
        {
            ConsoleHelper.AfficherEntete("Afficher");
            this.liste = MethodesDossier.GetDossiers();
            ConsoleHelper.AfficherListe(this.liste, strategieAffichageDossiers);
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau");

            DossierReservation dossier = new DossierReservation()
            {
                NumeroCarteBancaire = ConsoleSaisie.SaisirChaineObligatoire("Numero de Carte Bancaire ?"),
                PrixParPersonne = ConsoleSaisie.SaisirDecimalObligatoire("Prix Par Personne ?"),
                IdClient = ConsoleSaisie.SaisirEntierObligatoire("ID du client"),

                IdParticipant = ConsoleSaisie.SaisirEntierObligatoire("ID du Participant"),


            };
            MethodesDossier.CreerDossier(dossier);
        }

        private void Supprimer()
        {
            Afficher("Supprimer un Dossier");
            MethodesDossier.SupprimerDossier();
        }

        private void Modifier()
        {
            Afficher("Modifier une Agence");

            DossierReservation choix = MethodesDossier.ChoisirDossier();


            choix.NumeroCarteBancaire = ConsoleSaisie.SaisirChaineObligatoire("Numero de Carte Bancaire ?");
            choix.PrixParPersonne = ConsoleSaisie.SaisirDecimalObligatoire("Prix Par Personne ?");
            choix.IdClient = ConsoleSaisie.SaisirEntierObligatoire("ID du client");

            choix.IdParticipant = ConsoleSaisie.SaisirEntierObligatoire("ID du Participant");

            MethodesDossier.ModifierDossier(choix);
        }
    }
}
