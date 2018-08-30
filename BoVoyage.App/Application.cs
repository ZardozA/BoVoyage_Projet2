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

        public ModuleAgences ModuleAgences { get; private set; }

        protected override void InitialiserModules()
        {
            this.ModuleAgences = this.AjouterModule(new ModuleAgences(this, "Gestion des Agences"));
            
        }
    }
}
