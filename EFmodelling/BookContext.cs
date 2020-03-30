using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFmodelling
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers {get;set;}
        public DbSet<PriceOffer> PriceOffers { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("BookInfo");
            modelBuilder.Entity<Book>().HasIndex(b => b.PublisherId);
            modelBuilder.Entity<BookAuthor>().HasKey(x => new { x.BookISBN, x.AuthorId });
            modelBuilder.Entity<Book>()
            .HasOne(b => b.PriceOffer)
            .WithOne(i => i.Book)
            .HasForeignKey<PriceOffer>(b => b.BookISBN);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=lenovo-pc\sqlexpress;Initial Catalog=bookDB;Integrated Security=True");
        }
    }
}
