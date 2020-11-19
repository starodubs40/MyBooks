using MyBooks.Areas.Identity.Data;
using MyBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Domain.Repositories.Abstract
{
    public interface IBookRepository
    {
        IQueryable<Book> GetBooks();
        Task<Book> GetBookById(string id);
        Book GetBookByName(string name);
        void SaveBook(Book entity);
        void DeleteBook(Guid id);
    }
}
