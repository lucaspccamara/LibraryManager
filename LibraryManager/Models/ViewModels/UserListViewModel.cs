using System.Collections.Generic;

namespace LibraryManager.Models.ViewModels
{
    public class UserListViewModel
    {
        public User User { get; set; }
        public ICollection<LoanHistory> LoanHistorys { get; set; }
    }
}
