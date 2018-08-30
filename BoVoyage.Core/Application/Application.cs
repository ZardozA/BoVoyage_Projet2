using BoVoyage.Core;
using BoVoyage.Framework.UI;

namespace BoVoyage.Core
{
    public class Application : ApplicationBase
    {
        public Application()
            : base("Bo Voyage - La Super Agence de Voyages moins chers !")
        {
        }

        public Module1 Module1 { get; private set; }

        protected override void InitialiserModules()
        {
            this.Module1 = this.AjouterModule(new Module1(this, "Gestion des Clients"));
            this.Module1 = this.AjouterModule(new Module1(this, "Gestion des Voyages"));
        }
    }
}
