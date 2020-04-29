using System;
using System.Collections.Generic;
using System.Text;

namespace EFcrud.Model
{
    public class Strip
    {
        public Strip(int nr, string titel)
        {
            Nr = nr;
            Titel = titel;
        }
        public Strip(int nr, string titel, Uitgeverij uitgever, Reeks reeks) : this(nr, titel)
        {
            Uitgever = uitgever;
            Reeks = reeks;
        }
        public Strip()
        {
        }

        public int StripID { get; set; }
        public int Nr { get; set; }
        public string Titel { get; set; }
        public Uitgeverij Uitgever { get; set; }
        public Reeks Reeks { get; set; }
        public ICollection<AuteurStrip> AuteursLink { get; set; } = new List<AuteurStrip>();
        public void VoegAuteurToe(Auteur auteur)
        {
            AuteursLink.Add(new AuteurStrip(auteur,this));
        }
        public override string ToString()
        {
            return $"Strip[ID:{StripID},Nr:{Nr},Titel:{Titel},Auteurs:{AuteursLink.Count},\nUitgever:{Uitgever},\nReeks:{Reeks}]";
        }
        public void ToonDetail()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(this);
            Console.ResetColor();
            foreach (var al in AuteursLink)
            {
                Console.WriteLine(al.Auteur);
            }
        }
    }
}
