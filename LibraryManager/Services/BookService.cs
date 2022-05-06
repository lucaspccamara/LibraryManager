using LibraryManager.Data;
using LibraryManager.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Services
{
    public class BookService
    {
        private readonly LibraryManagerContext _context;

        public BookService(LibraryManagerContext context)
        {
            _context = context;
        }

        public List<Book> FindAll()
        {
            return _context.Book.Include(obj => obj.Theme).ToList();
        }

        public void Insert(Book obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
