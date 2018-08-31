using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyage.Core;

namespace BoVoyage.App
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var dossiersReservations = MethodesDossier.GetDossiers();

            foreach (var dossier in dossiersReservations)
            {
                Console.Write($"({dossier.Id})");
             
            }
            Console.ReadKey();*/




            var application = new Application();
            application.Demarrer();
        }
    }
}