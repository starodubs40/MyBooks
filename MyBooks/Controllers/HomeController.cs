using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Domain;
using MyBooks.Domain.Entities;
using MyBooks.Models;

namespace MyBooks.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.Books.GetBooks());
        }

        public IActionResult AddBookToMyLibrary(Guid Id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            dataManager.MyLibraries.AddBookToMyLibrary(Id.ToString(), userId);

            return Redirect("/Home/MyBooks");
        }

        public IActionResult DeleteMyLibrary(Guid Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            dataManager.MyLibraries.DeleteMyLibrary(Id);

            return Redirect("/Home/MyBooks");
        }

        public IActionResult MyBooks()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<Book> books = new List<Book>();

            foreach (var lib in dataManager.MyLibraries.GetMyLibrary(userId))
            {
                books.Add(dataManager.Books.GetBookById(lib.BookId.ToString()));
            }

            return View(books);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
