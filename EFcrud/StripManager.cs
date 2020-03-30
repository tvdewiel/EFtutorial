using EFcrud.Data;
using EFcrud.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace EFcrud
{
    public class StripManager
    {
        public void InitialiseerDatabank(string path)
        {
            Dictionary<string, Uitgeverij> uitgeverijDict = new Dictionary<string, Uitgeverij>();
            Dictionary<string, Reeks> reeksDict = new Dictionary<string, Reeks>();
            Dictionary<string, Auteur> auteurDict = new Dictionary<string, Auteur>();
            HashSet<Strip> stripSet = new HashSet<Strip>();
            using (StreamReader r=new StreamReader(path))
            {
                string line;
                string titel;
                int nr;
                string reeks;
                string uitgeverij;
                string[] auteurs;
                
                while ((line = r.ReadLine()) != null)
                {
                    string[] ss = line.Split(';').Select(x=>x.Trim()).ToArray();
                    titel = ss[0];
                    nr = int.Parse(ss[1]);
                    reeks = ss[2];
                    auteurs = ss[3].Split(',').Select(x=>x.Trim()).ToArray();
                    uitgeverij = ss[4];
                    if (!reeksDict.ContainsKey(reeks)) reeksDict.Add(reeks, new Reeks(reeks));
                    if (!uitgeverijDict.ContainsKey(uitgeverij)) uitgeverijDict.Add(uitgeverij, new Uitgeverij(uitgeverij));
                    foreach (string auteur in auteurs) {
                        if (!auteurDict.ContainsKey(auteur))
                        {
                            auteurDict.Add(auteur, new Auteur(auteur));
                        }
                    }
                    Strip s= new Strip(nr, titel);
                    s.Reeks = reeksDict[reeks];
                    s.Uitgever = uitgeverijDict[uitgeverij];
                    foreach (string auteur in auteurs)
                    {
                        s.VoegAuteurToe(auteurDict[auteur]);
                    }
                    stripSet.Add(s);
                }
            }
            using(StripsContext ctx=new StripsContext())
            {
                ctx.Strips.AddRange(stripSet);
                ctx.SaveChanges();
            }
            Console.WriteLine("Einde DB initialisatie");
        }
    }
}
