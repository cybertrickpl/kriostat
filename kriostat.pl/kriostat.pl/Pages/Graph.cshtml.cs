using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace kriostat.pl.Pages
{
    public class GraphModelViewModel
    {
        [BindProperty]
        public string? A { get; set; }

        [BindProperty]
        public double? B { get; set; }

        [BindProperty]
        public double? C { get; set; }

        public string ZerosMessage()
        {
           
                if (string.IsNullOrEmpty(A))
                {
                    return "Uzupełnij A";
                }

           

            return "";


        }
    }
    public class GraphModel : PageModel
    {
        private readonly ILogger<GraphModel> _logger;
        public string? A { get; set; }

        [BindProperty]
        public GraphModelViewModel GraphModelViewModel { get; set; }

        

        public GraphModel(ILogger<GraphModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost(GraphModelViewModel graphModel)
        {


            return Page();
        }
    }
}