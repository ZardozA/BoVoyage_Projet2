using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BoVoyage.Core
{
    public class MethodesParticipant
    {
        public static List<Participant> GetPartipants()
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
        public static void SupprimerParticipant()
        {
            Participant participant = ChoisirParticipant();
            using (var contexte = new Contexte())
            {
                contexte.Entry(participant).State = EntityState.Deleted;
                contexte.SaveChanges();
            }
        }
        public static void ModifierParticipant(Participant participant)
        {
            using (var contexte = new Contexte())
            {
                contexte.Participants.Attach(participant);
                contexte.Entry(participant).State = EntityState.Modified;
                contexte.SaveChanges();
            }
        }
        public static Participant ChoisirParticipant()
        {

            Console.WriteLine("Quel participant (Id)?");

            var idParticipant = int.Parse(Console.ReadLine());

            using (var contexte = new Contexte())
            {
                return contexte.Participants
                    .Single(x => x.Id == idParticipant);
            }
        }
    }
}
