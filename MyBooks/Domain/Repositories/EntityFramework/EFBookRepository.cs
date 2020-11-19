using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MyBooks.Domain.Entities;
using MyBooks.Domain.Repositories.Abstract;
using Newtonsoft.Json.Linq;
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Domain.Repositories.EntityFramework
{
    public class EFBookRepository : IBookRepository
    {

        private readonly MyBooksContext context;

        private IMemoryCache cache;

        public EFBookRepository(MyBooksContext context , IMemoryCache memoryCache)
        {
            this.context = context;
            cache = memoryCache;
        }

        public void DeleteBook(Guid id)
        {
            context.Books.Remove(new Book() { Id = id });
            context.SaveChanges();
        }

        public IQueryable<Book> GetBooks()
        {
            return context.Books ;
        }

        public async Task<Book> GetBookById(string id)
        {
            Book book = null;

            if (!cache.TryGetValue(id, out book))
            {
                book = await context.Books.FirstOrDefaultAsync(p => p.Id.ToString() == id);
                if (book != null)
                {
                    cache.Set(book.Id, book,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                }
            }

            return book;
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
