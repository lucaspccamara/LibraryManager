using LibraryManager.Models;
using LibraryManager.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Controllers
{
    public class BookThemesController : Controller
    {
        private readonly BookThemeService _bookThemeService;

        public BookThemesController(BookThemeService bookThemeService)
        {
            _bookThemeService = bookThemeService;
        }

        // GET: BookThemes
        public IActionResult Index()
        {
            var list = _bookThemeService.FindAll();
            return View(list);
        }

        // GET: BookTheme/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookTheme/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookTheme bookTheme)
        {
            bookTheme.CreatedDate = DateTime.Now;

            _bookThemeService.Insert(bookTheme);
            return RedirectToAction(nameof(Index));

        }
    }
}
