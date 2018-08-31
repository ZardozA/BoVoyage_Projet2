using BoVoyage.Framework.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        public virtual ICollection<Participant> Participants { get; set; }

        
        /*public void Annuler(int RaisonAnnulationDossier)
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

        }*/

        public void ValiderSolvabilite()
        {
            Console.WriteLine("Verification de Solvabilité");
            Random r = new Random();
            if (r.Next(0, 101) < 99)//simulation de verification de la banque
            {
                Console.WriteLine("ok");
                Accepter();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Erreur, le dossier va etre annulé");
                Console.ReadKey();
                /*Annuler(1);*/
            }
            
        }
        public void Accepter()
        {
            this.EtatDossierReservation = 3;
            MethodesDossier.ModifierDossier(this);
        }
    }
}
