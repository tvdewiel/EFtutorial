using System;
using System.Collections.Generic;
using System.Text;

namespace EFmodelling
{
    public class PriceOffer
    {
        public int Id { get; set; }
        public double NewPrice { get; set; }
        public string PromoText { get; set; }
        public Book book { get; set; }
    }
}
