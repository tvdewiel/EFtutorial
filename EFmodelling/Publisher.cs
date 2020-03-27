using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFmodelling
{
    [Table("PublisherInfo")]
    public class Publisher
    {
        public Publisher(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        [Column("PublisherName")]
        public string Name { get; set; }
    }
}
