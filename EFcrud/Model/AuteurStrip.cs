using System;
using System.Collections.Generic;
using System.Text;

namespace EFcrud.Model
{
    public class AuteurStrip
    {
        public AuteurStrip(Auteur auteur, Strip strip)
        {
            Auteur = auteur;
            Strip = strip;
        }

        public AuteurStrip(int auteurID, int stripID)
        {
            AuteurID = auteurID;
            StripID = stripID;
        }

        public int AuteurID { get; set; }
        public Auteur Auteur { get; set; }
        public int StripID { get; set; }
        public Strip Strip { get; set; }
    }
}
