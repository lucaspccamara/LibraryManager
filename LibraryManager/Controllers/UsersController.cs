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

namespace LibraryManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
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
            user.CreatedDate = DateTime.Now;

            _userService.Insert(user);
            return RedirectToAction(nameof(Index));

        }
    }
}
