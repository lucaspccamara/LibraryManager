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

        public DbSet<LibraryManager.Models.User> User { get; set; }
    }
}
