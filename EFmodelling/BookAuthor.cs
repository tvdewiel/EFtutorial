using System;
using System.Collections.Generic;
using System.Text;

namespace EFmodelling
{
    public class BookAuthor
    {
        public string BookISBN {get;set;}
        public Book Book { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
