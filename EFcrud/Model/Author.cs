﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EFcrud.Model
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }

        //------------------------------
        //Relationships

        public ICollection<BookAuthor> BooksLink { get; set; }
    }
}
