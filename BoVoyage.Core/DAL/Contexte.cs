﻿using System.Data.Entity;

namespace BoVoyage.Core
{
    public class Contexte : DbContext
    {
        public DbSet<Assurance> Assurances { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<DossierReservation> DossiersReservations { get; set; }
        public DbSet<Voyage> Voyages { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<AgenceVoyage> AgencesVoyages { get; set; }
        public DbSet<AssuranceDossier> AssurancesDossiers { get; set; }
        public DbSet<DossierAnnule> DossiersAnnules { get; set; }

    }
}
