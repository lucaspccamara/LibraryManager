using System.Collections.Generic;

namespace LibraryManager.Models.ViewModels
{
    public class LoanHistoryEditViewModel
    {
        public LoanHistory LoanHistory { get; set; }
        public User Users { get; set; }
        public Book Books { get; set; }
    }
}
