using System;
using System.Collections.Generic;
using System.Text;

namespace EFmodelling
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public ICollection<BookAuthor> BooksLink { get; set; }
    }
}
