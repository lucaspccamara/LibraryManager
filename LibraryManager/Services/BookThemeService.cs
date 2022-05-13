using LibraryManager.Data;
using LibraryManager.Models;
using LibraryManager.Models.Enums;
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
            return _context.BookTheme.OrderBy(x => x.Theme).ToList();
        }

        public BookTheme FindById(int id)
        {
            return _context.BookTheme.FirstOrDefault(obj => obj.Id == id);
        }

        public void Insert(BookTheme obj)
        {
            obj.CreatedDate = DateTime.Now;
            obj.IndAtivo = ActiveStatus.Sim;

            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Update(BookTheme obj)
        {
            var oldBookTheme = _context.BookTheme.FirstOrDefault(obj => obj.Id == obj.Id);

            obj.CreatedDate = oldBookTheme.CreatedDate;
            obj.UpdatedDate = DateTime.Now;
            obj.DeletedDate = oldBookTheme.DeletedDate;

            _context.Update(obj);
            _context.SaveChanges();
        }

        public void Delete(BookTheme obj)
        {
            obj.IndAtivo = ActiveStatus.Não;
            obj.DeletedDate = DateTime.Now;

            _context.Update(obj);
            _context.SaveChanges();
        }
    }
}
