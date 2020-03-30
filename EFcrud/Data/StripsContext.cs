using EFcrud.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFcrud.Data
{
    public class StripsContext : DbContext
    {
        public DbSet<Strip> Strips { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Reeks> Reeksen { get; set; }
        public DbSet<Uitgeverij> Uitgeverijen { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=lenovo-pc\sqlexpress;Initial Catalog=stripsDB;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuteurStrip>().HasKey(x => new { x.StripID, x.AuteurID });            
        }
    }
}
