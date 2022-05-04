using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryManager.Models;

namespace LibraryManager.Data
{
    public class LibraryManagerContext : DbContext
    {
        public LibraryManagerContext (DbContextOptions<LibraryManagerContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookTheme> BookTheme { get; set; }

    }
}
