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
                InformationAffichage.Creer<DossierReservation>(x=>x.NumeroCarteBancaire, "N° Carte Bancaire", 20),
                InformationAffichage.Creer<DossierReservation>(x=>x.PrixParPersonne, "Prix par personne", 20),
                InformationAffichage.Creer<DossierReservation>(x=>x.IdClient, "Id Client", 3),


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
            ConsoleHelper.AfficherEntete("Afficher les dossiers de réservation");
            this.liste = MethodesDossier.GetDossiers();
            ConsoleHelper.AfficherListe(this.liste, strategieAffichageDossiers);
        }

        /*private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau dossier");

            DossierReservation dossier = new DossierReservation()
            {
                NumeroCarteBancaire = ConsoleSaisie.SaisirChaineObligatoire("Numero de Carte Bancaire ?"),
                PrixParPersonne = ConsoleSaisie.SaisirDecimalObligatoire("Prix Par Personne ?"),
                IdClient = ConsoleSaisie.SaisirEntierObligatoire("ID du client"),


            };
            MethodesDossier.CreerDossier(dossier);
        }*/

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau dossier");

            DossierReservation dossier = new DossierReservation();

            ModuleClients.AfficherClients("Liste des Clients");
            dossier.IdClient = MethodesDossier.Choisir("Choisir client (Id):");

            ModuleVoyages.AfficherVoyages("Liste des Voyages");
            dossier.IdVoyage = MethodesDossier.Choisir("Choisir voyage (Id):");

            dossier.NumeroCarteBancaire = ConsoleSaisie.SaisirChaineObligatoire("Numero de Carte Bancaire ?");
            dossier.PrixParPersonne = ConsoleSaisie.SaisirDecimalObligatoire("Prix Par Personne ?");
            MethodesDossier.CreerDossier(dossier);


            NouveauDossierParticipant(dossier);

        }

        private void NouveauDossierParticipant(DossierReservation dossier)
        {
            int nbParticipants = 1;
            do
            {
                nbParticipants = ConsoleSaisie.SaisirEntierObligatoire("Indiquer le nombre de participants qui doit être inférieur à 9:");
            }
            while (nbParticipants > 9);

            List<Participant> listParticipants = new List<Participant>();

            for (var i = nbParticipants; i > 0; i--)
            {
                Console.WriteLine("Voulez-vous créer un nouveau participant (O/N)?");
                var choix = Console.ReadLine();
                switch (choix)
                {
                    case "O":
                        {
                            Participant participant = new Participant()
                            {
                                Civilite = ConsoleSaisie.SaisirChaineObligatoire("Civilité ?"),
                                Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom ?"),
                                Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prénom?"),
                                Adresse = ConsoleSaisie.SaisirChaineObligatoire("Adresse ?"),
                                Telephone = ConsoleSaisie.SaisirChaineObligatoire("Téléphone ?"),
                                DateNaissance = ConsoleSaisie.SaisirDateObligatoire("Date de Naissance ?"),
                                IdDossier = dossier.Id,
                            };
                            OutilsReservation.CalculerReductionAge(participant);
                            MethodesParticipant.CreerParticipant(participant);
                            listParticipants.Add(MethodesParticipant.ChoisirParticipant());
                        }
                        break;

                    case "N":
                        {

                            ModuleParticipants.AfficherParticipants("Liste des participants");
                            Participant participant = MethodesParticipant.ChoisirParticipant();
                            participant.IdDossier = dossier.Id;
                            MethodesParticipant.ModifierParticipant(participant);
                            listParticipants.Add(participant);

                        }
                        break;


                }
                Console.WriteLine($"Ce voyage coute {OutilsReservation.CalculerValeurVoyage(listParticipants, dossier)} Euros");

                ValiderDossier(dossier);
             


            }
        }

        private void ValiderDossier(DossierReservation dossier)
        {
           //DossierReservation.ValiderSolvabilite();
        }

        private void Supprimer()
        {
            Afficher("Supprimer un Dossier");
            MethodesDossier.SupprimerDossier();
        }

        private void Modifier()
        {
            Afficher("Modifier un Dossier");

            DossierReservation choix = MethodesDossier.ChoisirDossier();


            choix.NumeroCarteBancaire = ConsoleSaisie.SaisirChaineObligatoire("Numero de Carte Bancaire ?");
            choix.PrixParPersonne = ConsoleSaisie.SaisirDecimalObligatoire("Prix Par Personne ?");
            choix.IdClient = ConsoleSaisie.SaisirEntierObligatoire("ID du client");


            MethodesDossier.ModifierDossier(choix);
        }
    }
}
