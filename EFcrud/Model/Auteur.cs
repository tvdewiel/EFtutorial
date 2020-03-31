using System;
using System.Collections.Generic;
using System.Text;

namespace EFcrud.Model
{
    public class Auteur
    {
        public Auteur(string naam)
        {
            Naam = naam;
        }
        public int AuteurID { get; set; }
        public string Naam { get; set; }
        public ICollection<AuteurStrip> StripsLink { get; set; } = new List<AuteurStrip>();
        public override string ToString()
        {
            return $"Auteur[ID:{AuteurID},Naam:{Naam},strips:{StripsLink.Count}]";
        }
    }
}
