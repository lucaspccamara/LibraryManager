using LibraryManager.Models;
using LibraryManager.Models.ViewModels;
using LibraryManager.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookService _bookService;
        private readonly BookThemeService _bookThemeService;

        public BooksController(BookService bookService, BookThemeService bookThemeService)
        {
            _bookService = bookService;
            _bookThemeService = bookThemeService;
        }

        // GET: Books
        public IActionResult Index()
        {
            var list = _bookService.FindAll();
            return View(list);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            var bookThemes = _bookThemeService.FindAll();
            var vielModel = new BookThemeFormViewModel { BookThemes = bookThemes };
            return View(vielModel);
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            book.CreatedDate = DateTime.Now;

            _bookService.Insert(book);
            return RedirectToAction(nameof(Index));

        }
    }
}
