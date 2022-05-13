using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Models.Core;
using LibraryManager.Models.Enums;

namespace LibraryManager.Models
{
    public class LoanHistory : BaseEntity
    {
        public int Id { get; set; }

        [DisplayName("Código")]
        public int IdLoan { get; set; }

        [DisplayName("Usuário")]
        public User User { get; set; } = new User();

        [DisplayName("Usuário")]
        public int UserId { get; set; }

        [DisplayName("Livro")]
        public Book Book { get; set; } = new Book();

        [DisplayName("Livro")]
        public int BookId { get; set; }
        public LoanHistoryStatus  Status { get; set; }

        [DisplayName("Tipo")]
        public LoanType LoanType { get; set; }

        [DisplayName("Data de empréstimo")]
        public DateTime LoanDate { get; set; }

        [NotMapped]
        [DisplayName("Data de empréstimo")]
        public string LoanDateStr
        {
            get
            {
                if (this.LoanDate != null)
                {
                    return this.LoanDate.ToString("dd/MM/yyyy");
                }
                else
                {
                    return "-";
                }
            }
            set { }
        }

        [DisplayName("Data limite")]
        public DateTime ReturnDeadline { get; set; }

        [NotMapped]
        [DisplayName("Data limite")]
        public string ReturnDeadlineStr
        {
            get
            {
                if (this.ReturnDeadline != null)
                {
                    return this.ReturnDeadline.ToString("dd/MM/yyyy");
                }
                else
                {
                    return "-";
                }
            }
            set { }
        }

        [DisplayName("Data de devolução")]
        public DateTime? ReturnDate { get; set; }

        [NotMapped]
        [DisplayName("Data de devolução")]
        public string ReturnDateStr
        {
            get
            {
                if (this.ReturnDate != null)
                {
                    return this.ReturnDate.Value.ToString("dd/MM/yyyy");
                }
                else
                {
                    return "-";
                }
            }
            set { }
        }

        public LoanHistory()
        {
        }

        public LoanHistory(int id, int idLoan, User user, Book book, LoanHistoryStatus status, LoanType loanType, DateTime loanDate, DateTime returnDeadline, DateTime? returnDate)
        {
            Id = id;
            IdLoan = idLoan;
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
