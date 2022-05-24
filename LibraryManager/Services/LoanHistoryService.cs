using LibraryManager.Data;
using LibraryManager.Models;
using LibraryManager.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Services
{
    public class LoanHistoryService : Controller
    {
        private readonly LibraryManagerContext _context;

        public LoanHistoryService(LibraryManagerContext context)
        {
            _context = context;
        }

        public List<LoanHistory> FindAll()
        {
            return _context.LoanHistory.Include(x => x.User).Include(x => x.Book).Where(obj => obj.IndAtivo == ActiveStatus.Sim).OrderBy(obj => obj.ReturnDeadline).ToList();
        }

        public LoanHistory FindById(int id)
        {
            return _context.LoanHistory.Include(x => x.User).Include(x => x.Book).FirstOrDefault(obj => obj.Id == id);
        }

        public List<LoanHistory> FindLoanHistoryList(int idLoan)
        {
            return _context.LoanHistory.Include(x => x.User).Include(x => x.Book).Where(obj => obj.IdLoan == idLoan).OrderByDescending(obj => obj.Id).ToList();
        }

        public List<LoanHistory> FindBookHistoryList(int idUser)
        {
            return _context.LoanHistory.AsEnumerable().Where(obj => obj.UserId == idUser).OrderByDescending(obj => obj.Id).GroupBy(obj => obj.IdLoan).Select(obj => obj.FirstOrDefault()).Take(5).ToList();
        }

        public List<LoanHistory> FindUserHistoryList(int idBook)
        {
            return _context.LoanHistory.AsEnumerable().Where(obj => obj.BookId == idBook).OrderByDescending(obj => obj.Id).GroupBy(obj => obj.IdLoan).Select(obj => obj.FirstOrDefault()).Take(5).ToList();
        }

        public void Insert(LoanHistory obj)
        {
            var user = _context.User.FirstOrDefault(x => x.Id == obj.UserId);

            user.Status = UserStatus.Alugando;
            user.UpdatedDate = DateTime.Now;

            var book = _context.Book.Include(obj => obj.Theme).FirstOrDefault(x => x.Id == obj.BookId);

            book.Status = BookStatus.Emprestado;
            book.UpdatedDate = DateTime.Now;

            var sequence = _context.LoanHistory.Any() ? _context.LoanHistory.Max(obj => obj.IdLoan) : 0;

            obj.IdLoan = sequence + 1;
            obj.User = user;
            obj.Book = book;
            obj.LoanType = LoanType.Aluguel;
            obj.ReturnDeadline = obj.LoanDate.AddDays(14);
            obj.CreatedDate = DateTime.Now;
            obj.IndAtivo = ActiveStatus.Sim;

            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Update(LoanHistory obj)
        {
            var oldLoanHistory = _context.LoanHistory.FirstOrDefault(obj => obj.Id == obj.Id);

            obj.IdLoan = oldLoanHistory.IdLoan;
            obj.Status = oldLoanHistory.Status;
            obj.CreatedDate = oldLoanHistory.CreatedDate;
            obj.UpdatedDate = DateTime.Now;
            obj.DeletedDate = oldLoanHistory.DeletedDate;
            obj.IndAtivo = oldLoanHistory.IndAtivo;

            _context.Update(obj);
            _context.SaveChanges();
        }

        public void RenewLoan(LoanHistory obj)
        {
            var user = _context.User.FirstOrDefault(x => x.Id == obj.UserId);

            user.UpdatedDate = DateTime.Now;

            var book = _context.Book.Include(x => x.Theme).FirstOrDefault(x => x.Id == obj.BookId);

            book.UpdatedDate = DateTime.Now;

            var oldLoanHistory = _context.LoanHistory.Include(x => x.User).Include(x => x.Book).FirstOrDefault(x => x.Id == obj.Id);

            oldLoanHistory.UpdatedDate = DateTime.Now;
            oldLoanHistory.IndAtivo = ActiveStatus.Não;

            _context.Update(oldLoanHistory);
            _context.SaveChanges();

            obj.Id = _context.LoanHistory.Max(x => x.Id) + 1;
            obj.IdLoan = oldLoanHistory.IdLoan;
            obj.User = user;
            obj.Book = book;
            obj.Status = LoanHistoryStatus.Renovado;
            obj.LoanType = LoanType.Renovação;
            obj.ReturnDeadline = oldLoanHistory.ReturnDeadline.Value.AddDays(7);
            obj.CreatedDate = DateTime.Now;
            obj.UpdatedDate = null;
            obj.DeletedDate = null;
            obj.IndAtivo = ActiveStatus.Sim;

            _context.Add(obj);
            _context.SaveChanges();
        }

        public void ReturnLoan(LoanHistory obj)
        {
            var user = _context.User.FirstOrDefault(x => x.Id == obj.UserId);

            user.UpdatedDate = DateTime.Now;
            if (user.Status == UserStatus.Faltoso)
            {
                user.Status = UserStatus.Penalizado;
                user.EndPenalizedPeriod = DateTime.Now.AddDays(2 * (DateTime.Now - obj.ReturnDeadline.Value).TotalDays);
            }
            else
            {
                user.Status = UserStatus.Livre;
                user.EndPenalizedPeriod = null;
            }

            var book = _context.Book.Include(x => x.Theme).FirstOrDefault(x => x.Id == obj.BookId);

            book.UpdatedDate = DateTime.Now;
            book.Status = BookStatus.Livre;

            var oldLoanHistory = _context.LoanHistory.Include(x => x.User).Include(x => x.Book).FirstOrDefault(x => x.Id == obj.Id);

            oldLoanHistory.UpdatedDate = DateTime.Now;
            oldLoanHistory.IndAtivo = ActiveStatus.Não;

            _context.Update(oldLoanHistory);
            _context.SaveChanges();

            obj.Id = _context.LoanHistory.Max(x => x.Id) + 1;
            obj.IdLoan = oldLoanHistory.IdLoan;
            obj.User = user;
            obj.Book = book;
            obj.Status = LoanHistoryStatus.Devolvido;
            obj.LoanType = LoanType.Devolução;
            obj.ReturnDeadline = null;
            obj.ReturnDate = DateTime.Now;
            obj.CreatedDate = DateTime.Now;
            obj.UpdatedDate = null;
            obj.DeletedDate = null;
            obj.IndAtivo = ActiveStatus.Não;

            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(LoanHistory obj)
        {
            obj.IndAtivo = ActiveStatus.Não;
            obj.DeletedDate = DateTime.Now;

            _context.Update(obj);
            _context.SaveChanges();
        }
    }
}
