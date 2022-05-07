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

        // GET: BookThemes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookThemes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookTheme bookTheme)
        {
            bookTheme.CreatedDate = DateTime.Now;

            _bookThemeService.Insert(bookTheme);
            return RedirectToAction(nameof(Index));
        }

        // GET: BookThemes/Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _bookThemeService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: BookThemes/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, BookTheme bookTheme)
        {
            if (id != bookTheme.Id)
            {
                return BadRequest();
            }

            _bookThemeService.Update(bookTheme);
            return RedirectToAction(nameof(Index));
        }

        // GET: BookThemes/Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _bookThemeService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // GET: BookThemes/Delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _bookThemeService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: BookThemes/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var bookTheme = _bookThemeService.FindById(id);
            if (bookTheme == null)
            {
                return NotFound();
            }

            _bookThemeService.Delete(bookTheme);
            return RedirectToAction(nameof(Index));
        }
    }
}
