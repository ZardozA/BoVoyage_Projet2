using BoVoyage.Core;
using BoVoyage.Framework.UI;

namespace BoVoyage.App
{
    public class Application : ApplicationBase
    {
        public Application()
            : base("Bo Voyage - La Super Agence de Voyages moins chers !")
        {
        }
        public ModuleClients ModuleClients { get; private set; }
        public ModuleParticipants ModuleParticipants { get; private set; }
        public ModuleVoyages ModuleVoyages { get; private set; }
        public ModuleAgences ModuleAgences { get; private set; }
        public ModuleDossiers ModuleDossiers { get; private set; }
        public ModuleDestinations ModuleDestinations { get; private set; }
        //public ModuleAssurances ModuleAssurances { get; private set; }

        protected override void InitialiserModules()
        {
            this.ModuleClients = this.AjouterModule(new ModuleClients(this, "Gestion des Clients"));
            this.ModuleParticipants = this.AjouterModule(new ModuleParticipants(this, "Gestion des Participants"));
            this.ModuleVoyages = this.AjouterModule(new ModuleVoyages(this, "Gestion des Voyages"));
            this.ModuleAgences = this.AjouterModule(new ModuleAgences(this, "Gestion des Agences"));
            this.ModuleDossiers = this.AjouterModule(new ModuleDossiers(this, "Gestion des Dossiers de Réservation"));
            this.ModuleDestinations = this.AjouterModule(new ModuleDestinations(this, "Gestion des Destinations"));
            //this.ModuleAssurances = this.AjouterModule(new ModuleAssurances(this, "Gestion des Assurances"));


        }
    }
}
