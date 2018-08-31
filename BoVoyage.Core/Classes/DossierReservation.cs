using BoVoyage.Framework.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace BoVoyage.Core
{
    [Table("DossiersReservations")]
    public class DossierReservation
    {
        public int Id { get; set; }

        public string NumeroCarteBancaire { get; set; }

        public decimal PrixParPersonne { get; set; }

        [NotMapped]
        public decimal PrixTotal { get; set; }

        public int IdVoyage { get; set; }
            [ForeignKey("IdVoyage")]
            public virtual Voyage Voyage { get; set; }

        public int IdClient { get; set; }
            [ForeignKey("IdClient")]
            public virtual Client Client { get; set; }

        [NotMapped]
        public byte EtatDossierReservation { get; set; }

        public virtual ICollection<Assurance> Assurances { get; set; }

        public virtual ICollection<Participant> ListParticipants { get; set; }

        /*
        public void Annuler(int RaisonAnnulationDossier)
        {
            switch (RaisonAnnulationDossier)
            {
                case 1:
                    this.RaisonAnnulationDossier = 1;
                    break;
                case 2:
                    this.RaisonAnnulationDossier = 2;
                    break;
            }               
            dossier.EtatDossierReservation = 2;
            MethodesDossier.ModifierDossier(dossier);

        }
        */

        public static string ValiderSolvabilite(DossierReservation dossier)
        {
            Console.WriteLine("Verification de Solvabilité");
            Random r = new Random();
            if (r.Next(0, 101) < 80)//simulation de verification de la banque
            {
                Console.WriteLine("ok");
                return "ok";
                
            }
            else
            {
                Console.WriteLine("Probleme de Solvabilité,\n le dossier Doit etre supprimé \n la suppression automatique n'est pas encore en place"); 
                using (var contexte = new Contexte())
                {
                    //contexte.Entry(dossier).State = EntityState.Deleted;
                    //contexte.SaveChanges();
                }
                Console.ReadKey();
                return "nok";
                
              
            }
            
        }
        public static void Accepter(DossierReservation dossier)
        {
            dossier.EtatDossierReservation = 3;
            MethodesDossier.ModifierDossier(dossier);
            Console.WriteLine("Dossier Accepté!");
            Console.ReadKey();
        }
    }
}
