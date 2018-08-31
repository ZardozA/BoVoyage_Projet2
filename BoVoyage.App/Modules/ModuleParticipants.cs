using System;
using System.Collections.Generic;
using BoVoyage.Framework.UI;
using BoVoyage.Core;

namespace BoVoyage.App
{
    public class ModuleParticipants : ModuleBase<Application>
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageParticipants =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Participant>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Participant>(x=>x.Nom, "Nom", 25),
                InformationAffichage.Creer<Participant>(x=>x.Prenom, "Prénom", 25),
                InformationAffichage.Creer<Participant>(x=>x.DateNaissance, "Date de Naissance", 25),
            };

        private List<Participant> liste = new List<Participant>();

        public ModuleParticipants(Application application, string nomModule)
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
            this.liste = MethodesParticipant.GetParticipants();
            ConsoleHelper.AfficherListe(this.liste, strategieAffichageParticipants);
        }

        private void Afficher()
        {
            ConsoleHelper.AfficherEntete("Afficher les Participants");
            this.liste = MethodesParticipant.GetParticipants();
            ConsoleHelper.AfficherListe(this.liste, strategieAffichageParticipants);
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau Participant");

            Participant participant = new Participant()
            {
                Civilite = ConsoleSaisie.SaisirChaineObligatoire("Civilité ?"),
                Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom ?"),
                Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prénom?"),
                Adresse = ConsoleSaisie.SaisirChaineObligatoire("Adresse ?"),
                Telephone = ConsoleSaisie.SaisirChaineObligatoire("Téléphone ?"),
                DateNaissance = ConsoleSaisie.SaisirDateObligatoire("Date de Naissance ?"),
                Reduction = ConsoleSaisie.SaisirEntierOptionnel("Réduction ?"),
            };
            MethodesParticipant.CreerParticipant(participant);
        }

        private void Supprimer()
        {
            Afficher("Supprimer un participant");
            MethodesParticipant.SupprimerParticipant();
        }

        private void Modifier()
        {
            Afficher("Modifier un participant");

            Participant choix = MethodesParticipant.ChoisirParticipant();

            choix.Civilite = ConsoleSaisie.SaisirChaineObligatoire("Civilite ?");
            choix.Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom ?");
            choix.Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prenom ?");
            choix.Adresse = ConsoleSaisie.SaisirChaineObligatoire("Adresse ?");
            choix.Telephone = ConsoleSaisie.SaisirChaineObligatoire("Telephone ?");
            choix.DateNaissance = ConsoleSaisie.SaisirDateObligatoire("DateNaissance ?");
            choix.Reduction = ConsoleSaisie.SaisirEntierOptionnel("Réduction ?");

            MethodesParticipant.ModifierParticipant(choix);
        }
    }
}
