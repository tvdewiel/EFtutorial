using System;
using System.Collections.Generic;
using System.Text;

namespace EFcrud.Model
{
    public class Reeks
    {
        public Reeks(string naam)
        {
            Naam = naam;
        }

        public int ReeksID { get; set; }
        public string Naam { get; set; }
        public ICollection<Strip> Strips { get; set; } = new List<Strip>();
        public override string ToString()
        {
            return $"Reeks [ID:{ReeksID},Naam:{Naam},aantal:{Strips.Count}]";
        }
    }
}
