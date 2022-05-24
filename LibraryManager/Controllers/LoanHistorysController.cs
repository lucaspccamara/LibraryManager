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
    public class LoanHistorysController : Controller
    {
        private readonly LoanHistoryService _loanHistoryService;
        private readonly UserService _userService;
        private readonly BookService _bookService;

        public LoanHistorysController(LoanHistoryService loanHistoryService, UserService userService, BookService bookService)
        {
            _loanHistoryService = loanHistoryService;
            _userService = userService;
            _bookService = bookService;
        }

        // GET: LoanHistorys
        public IActionResult Index()
        {
            var list = _loanHistoryService.FindAll();
            return View(list);
        }

        // GET: LoanHistorys/Create
        public IActionResult Create()
        {
            var users = _userService.FindAll();
            var books = _bookService.FindAll();
            var vielModel = new LoanHistoryFormViewModel { Users = users, Books = books };
            return View(vielModel);
        }

        // POST: LoanHistorys/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LoanHistory loanHistory)
        {
            var user = _userService.FindById(loanHistory.UserId);
            if (user == null)
            {
                return NotFound();
            }
            else if (user.Status == UserStatus.Alugando || user.Status == UserStatus.Faltoso || user.Status == UserStatus.Penalizado)
            {
                return BadRequest();
            }

            var book = _bookService.FindById(loanHistory.BookId);
            if (book == null)
            {
                return NotFound();
            }
            else if (book.Status == BookStatus.Emprestado)
            {
                return BadRequest();
            }
            else if (book.Status == BookStatus.Reservado) //Implementar busca por usuário da reserva
            {
                return BadRequest();
            }

            _loanHistoryService.Insert(loanHistory);
            return RedirectToAction(nameof(Index));
        }

        // GET: LoanHistorys/Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _loanHistoryService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            var users = _userService.FindById(obj.UserId);
            var books = _bookService.FindById(obj.BookId);
            var vielModel = new LoanHistoryEditViewModel { LoanHistory = obj, Users = users, Books = books };
            return View(vielModel);
        }

        // POST: LoanHistorys/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, LoanHistory loanHistory)
        {
            if (id != loanHistory.Id)
            {
                return BadRequest();
            }

            _loanHistoryService.Update(loanHistory);
            return RedirectToAction(nameof(Index));
        }

        // GET: LoanHistorys/RenewLoan
        public IActionResult RenewLoan(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _loanHistoryService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            var users = _userService.FindById(obj.UserId);
            var books = _bookService.FindById(obj.BookId);
            var vielModel = new LoanHistoryEditViewModel { LoanHistory = obj, Users = users, Books = books };
            return View(vielModel);
        }

        // POST: LoanHistorys/RenewLoan
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RenewLoan(int id, LoanHistory loanHistory)
        {
            if (id != loanHistory.Id)
            {
                return BadRequest();
            }

            loanHistory = _loanHistoryService.FindById(id);
            if (loanHistory == null)
            {
                return NotFound();
            }

            _loanHistoryService.RenewLoan(loanHistory);
            return RedirectToAction(nameof(Index));
        }

        // GET: LoanHistorys/ReturnLoan
        public IActionResult ReturnLoan(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _loanHistoryService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            var users = _userService.FindById(obj.UserId);
            var books = _bookService.FindById(obj.BookId);
            var vielModel = new LoanHistoryEditViewModel { LoanHistory = obj, Users = users, Books = books };
            return View(vielModel);
        }

        // POST: LoanHistorys/ReturnLoan
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ReturnLoan(int id, LoanHistory loanHistory)
        {
            if (id != loanHistory.Id)
            {
                return BadRequest();
            }

            loanHistory = _loanHistoryService.FindById(id);
            if (loanHistory == null)
            {
                return NotFound();
            }

            _loanHistoryService.ReturnLoan(loanHistory);
            return RedirectToAction(nameof(Index));
        }

        // GET: LoanHistorys/Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _loanHistoryService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            var loanHistorys = _loanHistoryService.FindLoanHistoryList(obj.IdLoan);

            var vielModel = new LoanHistoryListViewModel { LoanHistory = obj, LoanHistorys = loanHistorys };
            return View(vielModel);
        }

        // GET: LoanHistorys/Delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _loanHistoryService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: LoanHistorys/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var loanHistory = _loanHistoryService.FindById(id);
            if (loanHistory == null)
            {
                return NotFound();
            }

            _loanHistoryService.Delete(loanHistory);
            return RedirectToAction(nameof(Index));
        }
    }
}
