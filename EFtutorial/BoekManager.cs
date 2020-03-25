using EFtutorial.Data;
using EFtutorial.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFtutorial
{
    public class BoekManager
    {
        private BoekContext ctx = new BoekContext();
        public void VoegBoekToe(Boek boek)
        {
            ctx.Boeken.Add(boek);
            ctx.SaveChanges();
        }
        public void VoegUitgeverijToe(Uitgeverij uitgeverij)
        {
            ctx.Uitgeverijen.Add(uitgeverij);
            ctx.SaveChanges();
        }
        public void VoegAuteurToe(Auteur auteur)
        {
            ctx.Auteurs.Add(auteur);
            ctx.SaveChanges();
        }
        public Boek ZoekBoek(int boekID)
        {
            return ctx.Boeken.Find(boekID);
        }
        public void UpdateBoek(Boek boek)
        {
            ctx.Boeken.Update(boek);
            ctx.SaveChanges();
        }
        public void UpdateDB()
        {
            ctx.SaveChanges();
        }
    }
}
