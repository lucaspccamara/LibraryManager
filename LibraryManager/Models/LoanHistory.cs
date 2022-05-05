using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Models.Core;
using LibraryManager.Models.Enums;

namespace LibraryManager.Models
{
    public class LoanHistory : BaseEntity
    {
        public int Id { get; set; }
        public User User { get; set; } = new User();
        public Book Book { get; set; } = new Book();
        public LoanHistoryStatus  Status { get; set; }
        public LoanType LoanType { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDeadline { get; set; }
        public DateTime? ReturnDate { get; set; }

        public LoanHistory()
        {
        }

        public LoanHistory(int id, User user, Book book, LoanHistoryStatus status, LoanType loanType, DateTime loanDate, DateTime returnDeadline, DateTime? returnDate)
        {
            Id = id;
            User = user;
            Book = book;
            Status = status;
            LoanType = loanType;
            LoanDate = loanDate;
            ReturnDeadline = returnDeadline;
            ReturnDate = returnDate;
        }
    }
}
