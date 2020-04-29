using EFcrud.Data;
using EFcrud.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            using (StreamReader r = new StreamReader(path))
            {
                string line;           string titel;
                int nr;                string reeks;
                string uitgeverij;     string[] auteurs;
                while ((line = r.ReadLine()) != null)
                {
                    string[] ss = line.Split(';').Select(x => x.Trim()).ToArray();
                    titel = ss[0];
                    nr = int.Parse(ss[1]);
                    reeks = ss[2];
                    auteurs = ss[3].Split(',').Select(x => x.Trim()).ToArray();
                    uitgeverij = ss[4];
                    if (!reeksDict.ContainsKey(reeks)) reeksDict.Add(reeks, new Reeks(reeks));
                    if (!uitgeverijDict.ContainsKey(uitgeverij)) 
                        uitgeverijDict.Add(uitgeverij, new Uitgeverij(uitgeverij));
                    foreach (string auteur in auteurs) {
                        if (!auteurDict.ContainsKey(auteur))  auteurDict.Add(auteur, new Auteur(auteur));                        
                    }
                    Strip s = new Strip(nr, titel);
                    s.Reeks = reeksDict[reeks];
                    s.Uitgever = uitgeverijDict[uitgeverij];
                    foreach (string auteur in auteurs) {
                        s.VoegAuteurToe(auteurDict[auteur]);
                    }
                    stripSet.Add(s);
                }
            }
            using (StripsContext ctx = new StripsContext())
            {
                ctx.Strips.AddRange(stripSet);
                ctx.SaveChanges();
            }
            Console.WriteLine("Einde DB initialisatie");
        }
        public void ToonReeksen()
        {
            using (StripsContext ctx = new StripsContext())
            {
                foreach(Reeks r in ctx.Reeksen)
                {
                    Console.WriteLine(r);
                }
            }
        }
        public void ToonReeksenMetStrip()
        {
            using (StripsContext ctx = new StripsContext())
            {
                foreach (Reeks r in ctx.Reeksen.Include(x=>x.Strips))
                {
                    Console.WriteLine(r);
                }
            }
        }
        public void ToonStrips()
        {
            using (StripsContext ctx = new StripsContext())
            {
                foreach (Strip x in ctx.Strips)
                {
                    x.ToonDetail();
                    Console.WriteLine("-----------------------------------");
                }
            }
        }
        public void ToonStripsInclude()
        {
            using (StripsContext ctx = new StripsContext())
            {
                foreach (Strip x in ctx.Strips.Include(s=>s.Reeks)
                    .Include(s=>s.Uitgever)
                    .Include(s=>s.AuteursLink).ThenInclude(l=>l.Auteur))
                {
                    x.ToonDetail();
                    Console.WriteLine("-----------------------------------");
                }
            }
        }
        public void ToonStripsFilter()
        {
            using (StripsContext ctx = new StripsContext())
            {
                foreach (Strip x in ctx.Strips.Where(s=>s.Reeks.Naam=="Thorgal"))
                {
                    x.ToonDetail();
                    Console.WriteLine("-----------------------------------");
                }
            }
        }
        public void ToonStripsIncludeAsNoTracking()
        {
            using (StripsContext ctx = new StripsContext())
            {
                foreach (Strip x in ctx.Strips.Include(s => s.Reeks)
                    .Include(s => s.Uitgever)
                    .Include(s => s.AuteursLink).ThenInclude(l => l.Auteur)
                    .AsNoTracking())
                {
                    x.ToonDetail();
                    Console.WriteLine("-----------------------------------");
                }
            }
        }
        public void UpdateStrip()
        {
            using (StripsContext ctx = new StripsContext())
            {
                Strip strip = ctx.Strips.Single(x => x.StripID == 26);
                strip.Titel = "Het sterrenkind";
                strip.Nr = 7;
                ctx.SaveChanges();
            }
        }
        public void VerwijderStrip()
        {
            using (StripsContext ctx = new StripsContext())
            {
                Strip strip = ctx.Strips.Single(x => x.StripID == 26);
                ctx.Strips.Remove(strip);

                ctx.Strips.Remove(new Strip() { StripID = 27 });
                ctx.SaveChanges();
            }
        }
    }
}
