using EFtutorial.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFtutorial.Data
{
    public class BoekContext : DbContext
    {
        public DbSet<Boek> Boeken { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Uitgeverij> Uitgeverijen { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=lenovo-pc\sqlexpress;Initial Catalog=boekDB;Integrated Security=True");
        }
    }
}
