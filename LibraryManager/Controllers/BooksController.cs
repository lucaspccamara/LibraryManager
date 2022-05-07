using LibraryManager.Models;
using LibraryManager.Models.Enums;
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
            var vielModel = new BookFormViewModel { BookThemes = bookThemes };
            return View(vielModel);
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            _bookService.Insert(book);
            return RedirectToAction(nameof(Index));
        }

        // GET: Book/Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _bookService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            List<BookTheme> bookThemes = _bookThemeService.FindAll();
            BookFormViewModel viewModel = new BookFormViewModel { Book = obj, BookThemes = bookThemes };

            return View(viewModel);
        }

        // POST: Book/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _bookService.Update(book);
            return RedirectToAction(nameof(Index));
        }

        // GET: Book/Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _bookService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // GET: Book/Delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _bookService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: Book/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var book = _bookService.FindById(id);
            if (book == null)
            {
                return NotFound();
            }

            _bookService.Delete(book);
            return RedirectToAction(nameof(Index));
        }
    }
}
