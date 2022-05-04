using LibraryManager.Models.Core;
using LibraryManager.Models.Enums;

namespace LibraryManager.Models
{
    public class Book : BaseEntity
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public BookTheme Theme { get; set; }
        public BookStatus Status { get; set; }

        public Book()
        {
        }

        public Book(int id, string bookName, string author, BookTheme theme, BookStatus status)
        {
            Id = id;
            BookName = bookName;
            Author = author;
            Theme = theme;
            Status = status;
        }
    }
}
