using LibraryManager.Models.Core;

namespace LibraryManager.Models
{
    public class BookTheme : BaseEntity
    {
        public int Id { get; set; }
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
