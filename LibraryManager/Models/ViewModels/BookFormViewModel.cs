using System.Collections.Generic;

namespace LibraryManager.Models.ViewModels
{
    public class BookFormViewModel
    {
        public Book Book { get; set; }
        public ICollection<BookTheme> BookThemes { get; set; }
    }
}
