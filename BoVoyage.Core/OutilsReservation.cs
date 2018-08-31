using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Core
{
    public class OutilsReservation
    {
        public static decimal CalculerValeurVoyage(List<Participant> listParticipants,DossierReservation dossier)
        {
            
            foreach (Participant participant in listParticipants)

            {
                CalculerReductionAge(participant);      
                dossier.PrixTotal += decimal.Multiply(dossier.PrixParPersonne, Convert.ToDecimal(participant.Reduction));              
            }

            return dossier.PrixTotal;
        }

        public static void CalculerReductionAge(Participant participant)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - participant.DateNaissance.Year;
            if (now < participant.DateNaissance.AddYears(age))
            {
                age--;
            }
            if (age < 12)
            {
                participant.Reduction = 0.4;
                MethodesParticipant.ModifierParticipant(participant);
            }
            else
            {
                participant.Reduction = 1;
                MethodesParticipant.ModifierParticipant(participant);
            }
        }


    }
}
