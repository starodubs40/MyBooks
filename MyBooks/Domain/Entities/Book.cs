using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }

        public string ImagePath { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
    }
}
