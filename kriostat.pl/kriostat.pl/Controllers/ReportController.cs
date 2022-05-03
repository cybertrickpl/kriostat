using kriostat.pl.Models.Report;
using Microsoft.AspNetCore.Mvc;

namespace kriostat.pl.Controllers
{
    public class ReportController : Controller
    {

        [HttpGet]
        public IActionResult Index(int? id, string? fn)
        {
            IndexViewModel model = new IndexViewModel();
            if (!id.HasValue)
            {
                model.Year = DateTime.Now.Year;
            }
            else
            {
                model.Year = id.Value;
            }

            model.FirstName = fn;


            return View(model);
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel model)
        {
           
            return View(model);
        }
    }
}
