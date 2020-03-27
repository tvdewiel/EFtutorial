using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFmodelling
{
    public class Review
    {
        public Review(string text, int stars)
        {
            Text = text;
            Stars = stars;
        }

        public int ReviewID { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Text { get; set; }
        public int Stars { get; set; }
    }
}
