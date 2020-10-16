using System;

namespace MyBooks.Domain.Entities
{
    public class MyLibrary
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }
            
        public string BookId { get; set; }
    }
}
