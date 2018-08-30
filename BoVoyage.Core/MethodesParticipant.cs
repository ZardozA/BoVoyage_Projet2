using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BoVoyage.Core
{
    public class MethodesParticipant
    {
        public static List<Participant> GetParticipants()
        {
            using (var contexte = new Contexte())
            {
                var participants = contexte.Participants
                    .OrderBy(x => x.Id).ToList();
                return participants;
            }
        }
        public static void CreerParticipant(Participant participant)
        {
            using (var contexte = new Contexte())
            {
                contexte.Participants.Add(participant);
                contexte.SaveChanges();
            }
        }
        public void SupprimerParticipant()
        {
            Participant participant = ChoisirParticipant();
            using (var contexte = new Contexte())
            {
                contexte.Entry(participant).State = EntityState.Deleted;
                contexte.SaveChanges();
            }
        }
        private static void ModifierParticipant(Participant participant)
        {
            using (var contexte = new Contexte())
            {
                contexte.Participants.Attach(participant);
                contexte.Entry(participant).State = EntityState.Modified;
                contexte.SaveChanges();
            }
        }
        private static Participant ChoisirParticipant()
        {
            Console.WriteLine("Quelle participant (Id)?");
            var idParticipant = int.Parse(Console.ReadLine());

            using (var contexte = new Contexte())
            {
                return contexte.Participants
                    .Single(x => x.Id == idParticipant);
            }
        }

        //implementation Modification
        /*
          private void Modifier()
        {
            ConsoleHelper.AfficherEntete("Modifier un Dossier");
            Participant choix = MethodesParticipant.ChoisirParticipant();

            choix.Civilite = ConsoleSaisie.SaisirChaineObligatoire("Civilite ?");
            choix.Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom ?");
            choix.Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prenom ?");
            choix.Adresse = ConsoleSaisie.SaisirChaineObligatoire("Adresse ?");
            choix.Telephone = ConsoleSaisie.SaisirChaineObligatoire("Telephone ?");
            choix.DateNaissance = ConsoleSaisie.SaisirDateObligatoire("DateNaissance ?");
            choix.Reduction = ConsoleSaisie.SaisirEntierOptionnel("Reduction (optionel) ?");
            
            MethodesParticipant.ModifierParticipant(choix);
        }
        */

    }
}
