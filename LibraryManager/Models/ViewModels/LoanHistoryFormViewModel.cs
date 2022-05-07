using System.Collections.Generic;

namespace LibraryManager.Models.ViewModels
{
    public class LoanHistoryFormViewModel
    {
        public LoanHistory LoanHistory { get; set; }
        public ICollection<User> User { get; set; }
        public ICollection<Book> Book { get; set; }
    }
}
