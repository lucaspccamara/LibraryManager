using System.Collections.Generic;

namespace LibraryManager.Models.ViewModels
{
    public class BookListViewModel
    {
        public Book Book { get; set; }
        public ICollection<LoanHistory> LoanHistorys { get; set; }
    }
}
