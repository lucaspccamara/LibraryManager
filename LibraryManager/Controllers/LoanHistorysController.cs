using LibraryManager.Models;
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

        public LoanHistorysController(LoanHistoryService loanHistoryService)
        {
            _loanHistoryService = loanHistoryService;
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
            return View();
        }

        // POST: LoanHistorys/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LoanHistory loanHistory)
        {
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

            return View(obj);
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

            return View(obj);
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
