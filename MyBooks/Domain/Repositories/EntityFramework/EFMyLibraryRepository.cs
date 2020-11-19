using Microsoft.Extensions.Caching.Memory;
using MyBooks.Domain.Entities;
using MyBooks.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Domain.Repositories.EntityFramework
{
    public class EFMyLibraryRepository : IMyLibraryRepository
    {
        private readonly MyBooksContext context;
        private IMemoryCache cache;

        public EFMyLibraryRepository(MyBooksContext context, IMemoryCache memoryCache)
        {
            this.context = context;
            cache = memoryCache;
        }

        public async Task AddBookToMyLibrary(string bookId , string userId)
        {
            MyLibrary item = new MyLibrary { UserId = userId, BookId = bookId };
            //
            context.MyLibraries.Add(item);

            int n = await context.SaveChangesAsync();
            if (n > 0)
            {
                cache.Set(item.Id, item, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                });
            }
        }

        public void DeleteMyLibrary(Guid id)
        {
            context.MyLibraries.Remove( context.MyLibraries.FirstOrDefault(x => x.BookId == id.ToString() ) );
            context.SaveChanges();
        }

        public IQueryable<MyLibrary> GetMyLibrary(string UserId)
        {
            return context.MyLibraries.Where(x => x.UserId == UserId);
        }
    }
}
