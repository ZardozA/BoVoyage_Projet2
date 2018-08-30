﻿using System;

namespace BoVoyage.Core
{
    public abstract class Personne
    {
        public string Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenomd { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public DateTime DateNaissance { get; set; }

        public int Age { get; set; }

    }
}