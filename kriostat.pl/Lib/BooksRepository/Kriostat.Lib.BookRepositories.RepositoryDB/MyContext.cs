using Kriostat.Lib.BookRepositories.RepositoryDB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kriostat.Lib.BookRepositories.RepositoryDB
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions options): base(options)
        {
            
        }

        public virtual DbSet<BookDB> Books { get; set; }
    }
}