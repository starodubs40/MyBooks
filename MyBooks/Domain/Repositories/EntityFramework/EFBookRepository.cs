using Microsoft.EntityFrameworkCore;
using MyBooks.Domain.Entities;
using MyBooks.Domain.Repositories.Abstract;
//
using System;
using System.Linq;

namespace MyBooks.Domain.Repositories.EntityFramework
{
    public class EFBookRepository : IBookRepository
    {

        private readonly MyBooksContext context;

        public EFBookRepository(MyBooksContext context)
        {
            this.context = context;
        }

        public void DeleteBook(Guid id)
        {
            context.Books.Remove(new Book() { Id = id });
            context.SaveChanges();
        }

        public IQueryable<Book> GetBooks()
        {
            return context.Books;
        }

        public Book GetBookById(string id)
        {
            return context.Books.FirstOrDefault(x => x.Id.ToString() == id);
        }

        public Book GetBookByName(string name)
        {
            throw new NotImplementedException();
        }

        public void SaveBook(Book entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
