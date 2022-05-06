using LibraryManager.Models.Core;
using System.ComponentModel;

namespace LibraryManager.Models
{
    public class BookTheme : BaseEntity
    {
        public int Id { get; set; }

        [DisplayName("Tema")]
        public string Theme { get; set; }

        public BookTheme()
        {
        }

        public BookTheme(int id, string theme)
        {
            Id = id;
            Theme = theme;
        }
    }
}
