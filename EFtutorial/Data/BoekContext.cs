using EFtutorial.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFtutorial.Data
{
    public class BoekContext : DbContext
    {
       //public static readonly ILoggerFactory factory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public DbSet<Boek> Boeken { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Uitgeverij> Uitgeverijen { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseLoggerFactory(factory)  //tie-up DbContext with LoggerFactory object
           //.EnableSensitiveDataLogging()
           optionsBuilder.UseSqlServer(@"Data Source=NB21-6CDPYD3\SQLEXPRESS;Initial Catalog=EFtutorial;Integrated Security=True;TrustServerCertificate=True")
                .LogTo(Console.WriteLine);
        }
    }
}
