using LibraryManager.Data;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Services
{
    public class BookThemeService
    {
        private readonly LibraryManagerContext _context;

        public BookThemeService(LibraryManagerContext context)
        {
            _context = context;
        }

        public List<BookTheme> FindAll()
        {
            return _context.BookTheme.ToList();
        }

        public void Insert(BookTheme obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
