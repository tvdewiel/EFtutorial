using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFmodelling
{
    public class Book
    {
        public Book(string ISBN, string title, int? numberOfPages)
        {
            this.ISBN = ISBN;
            Title = title;
            NumberOfPages = numberOfPages;
        }

        [Key]
        public string ISBN { get; set; }
        [MaxLength(500)]
        [Required]
        public string Title { get; set; }
        public int? NumberOfPages { get; set; }
        public List<Review> Reviews { get; private set; } = new List<Review>();
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public double Price { get; set; }
        public PriceOffer PriceOffer { get; set; }
        public ICollection<BookAuthor> AuthorsLink { get; set; }
    }
}
