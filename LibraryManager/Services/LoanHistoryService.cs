using LibraryManager.Data;
using LibraryManager.Models;
using LibraryManager.Models.Enums;
using Microsoft.AspNetCore.Mvc;
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
            return _context.LoanHistory.OrderBy(obj => obj.ReturnDeadline).ToList();
        }

        public LoanHistory FindById(int id)
        {
            return _context.LoanHistory.FirstOrDefault(obj => obj.Id == id);
        }

        public void Insert(LoanHistory obj)
        {
            obj.CreatedDate = DateTime.Now;

            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Update(LoanHistory obj)
        {
            var oldLoanHistory = _context.LoanHistory.FirstOrDefault(obj => obj.Id == obj.Id);

            obj.Status = oldLoanHistory.Status;
            obj.CreatedDate = oldLoanHistory.CreatedDate;
            obj.UpdatedDate = DateTime.Now;
            obj.DeletedDate = oldLoanHistory.DeletedDate;

            _context.Update(obj);
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
