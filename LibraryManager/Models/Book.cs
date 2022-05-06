using LibraryManager.Models.Core;
using LibraryManager.Models.Enums;
using System.ComponentModel;

namespace LibraryManager.Models
{
    public class Book : BaseEntity
    {
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string BookName { get; set; }

        [DisplayName("Autor")]
        public string Author { get; set; }

        [DisplayName("Tema")]
        public BookTheme Theme { get; set; }

        [DisplayName("Tema")]
        public int BookThemeId { get; set; }
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
