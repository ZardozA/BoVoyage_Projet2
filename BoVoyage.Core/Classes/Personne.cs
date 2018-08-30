using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.Core
{
    public abstract class Personne
    {
        public string Civilite { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Adresse { get; set; }

        public string Telephone { get; set; }

        public DateTime DateNaissance { get; set; }

        [NotMapped]
        public int Age { get; set; }

    }
}
