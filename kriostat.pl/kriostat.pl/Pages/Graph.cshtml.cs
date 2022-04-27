using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace kriostat.pl.Pages
{
    public class GraphModel : PageModel
    {
        private readonly ILogger<GraphModel> _logger;

        public GraphModel(ILogger<GraphModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}