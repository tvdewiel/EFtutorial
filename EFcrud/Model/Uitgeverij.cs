using System;
using System.Collections.Generic;
using System.Text;

namespace EFcrud.Model
{
    public class Uitgeverij
    {
        public Uitgeverij(string naam)
        {
            Naam = naam;
        }

        public int UitgeverijID { get; set; }
        public string Naam { get; set; }
    }
}
