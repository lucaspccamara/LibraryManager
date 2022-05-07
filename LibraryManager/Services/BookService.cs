using LibraryManager.Data;
using LibraryManager.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LibraryManager.Models.Enums;
using System;

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
            return _context.Book.Include(obj => obj.Theme).OrderBy(obj => obj.BookName).ToList();
        }

        public Book FindById(int id)
        {
            return _context.Book.Include(obj => obj.Theme).FirstOrDefault(obj => obj.Id == id);
        }

        public void Insert(Book obj)
        {
            obj.CreatedDate = DateTime.Now;

            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Book obj)
        {
            var oldBook = _context.Book.Include(obj => obj.Theme).FirstOrDefault(obj => obj.Id == obj.Id);

            obj.Status = oldBook.Status;
            obj.CreatedDate = oldBook.CreatedDate;
            obj.UpdatedDate = DateTime.Now;
            obj.DeletedDate = oldBook.DeletedDate;

            _context.Update(obj);
            _context.SaveChanges();
        }

        public void Delete(Book obj)
        {
            obj.IndAtivo = ActiveStatus.Não;
            obj.DeletedDate = DateTime.Now;

            _context.Update(obj);
            _context.SaveChanges();
        }
    }
}
