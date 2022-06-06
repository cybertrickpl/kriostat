using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kriostat.Lib.BookRepositories.RepositoryDB.Entities
{
    [Table("Book")]
    public class BookDB
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }
    }
}
