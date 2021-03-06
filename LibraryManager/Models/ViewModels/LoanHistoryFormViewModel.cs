using System.Collections.Generic;

namespace LibraryManager.Models.ViewModels
{
    public class LoanHistoryFormViewModel
    {
        public LoanHistory LoanHistory { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
