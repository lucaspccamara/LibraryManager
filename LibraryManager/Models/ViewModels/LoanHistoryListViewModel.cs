using System.Collections.Generic;

namespace LibraryManager.Models.ViewModels
{
    public class LoanHistoryListViewModel
    {
        public LoanHistory LoanHistory { get; set; }
        public ICollection<LoanHistory> LoanHistorys { get; set; }
    }
}
