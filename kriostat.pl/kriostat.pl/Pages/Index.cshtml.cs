using kriostat.pl.Warehouse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Serialization;
using System.Linq;
using Kriostat.Lib.Common.Entities;
using Kriostat.Lib.Common.Interfaces;
using Kriostat.Lib.BooksRepository.FS;
using Kriostat.Lib.BooksRepository.Fake;
using Kriostat.Lib.BookRepositories.RepositoryDB;

namespace kriostat.pl.Pages
{
    


    public class IndexModel : PageModel
    {
        


        public IndexModel(ILogger<IndexModel> logger, MyContext context)
        {
            
        }

        

        public IActionResult OnGet(Guid? deleteRow, Guid? editRow)
        {
            
            
                       

            return Page();
        }
           

       
    }
}