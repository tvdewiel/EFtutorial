using System;
using System.Collections.Generic;
using System.Text;

namespace EFcrud.Model
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string VoterName { get; set; }
        public int NumStars { get; set; }
        public string Comment { get; set; }

        //-----------------------------------------
        //Relationships

        public int BookId { get; set; }
    }
}
