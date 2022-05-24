using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManager.Data;
using LibraryManager.Models;
using LibraryManager.Services;
using LibraryManager.Models.ViewModels;

namespace LibraryManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserService _userService;
        private readonly LoanHistoryService _loanHistoryService;
        private readonly BookService _bookService;

        public UsersController(UserService userService, LoanHistoryService loanHistoryService, BookService bookService)
        {
            _userService = userService;
            _loanHistoryService = loanHistoryService;
            _bookService = bookService;
        }

        // GET: Users
        public IActionResult Index()
        {
            var list = _userService.FindAll();
            return View(list);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            _userService.Insert(user);
            return RedirectToAction(nameof(Index));

        }

        // GET: Users/Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _userService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: Users/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _userService.Update(user);
            return RedirectToAction(nameof(Index));
        }

        // GET: Users/Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _userService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            var loanHistorys = _loanHistoryService.FindBookHistoryList(obj.Id);

            foreach (var loan in loanHistorys) {
                loan.Book = _bookService.FindById(loan.BookId);
            }

            var vielModel = new UserListViewModel { User = obj, LoanHistorys = loanHistorys };
            return View(vielModel);
        }

        // GET: Users/Delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _userService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: Users/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var book = _userService.FindById(id);
            if (book == null)
            {
                return NotFound();
            }

            _userService.Delete(book);
            return RedirectToAction(nameof(Index));
        }
    }
}
