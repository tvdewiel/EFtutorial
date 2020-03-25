using System;
using System.Collections.Generic;
using System.Text;

namespace EFtutorial.Model
{
    public class Boek
    {
        public Boek(string titel, string beschrijving)
        {
            Titel = titel;
            Beschrijving = beschrijving;
        }

        public Boek(string titel, string beschrijving, Uitgeverij uitgeverij, List<Auteur> auteurs)
        {
            Titel = titel;
            Beschrijving = beschrijving;
            Uitgeverij = uitgeverij;
            Auteurs = auteurs;
        }
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Beschrijving { get; set; }
        public Uitgeverij Uitgeverij { get; set; }
        public List<Auteur> Auteurs { get; set; } = new List<Auteur>();
    }
}
