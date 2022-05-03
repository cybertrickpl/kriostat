using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace kriostat.pl.Pages
{
    public class RaportModel : PageModel
    {
        private int year;
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }

        private readonly ILogger<RaportModel> _logger;

        public RaportModel(ILogger<RaportModel> logger)
        {
            _logger = logger;

            Year = 2022;
        }

        public void OnGet()
        {
        }
    }
}