using kriostat.pl.Warehouse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace kriostat.pl.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public int Count { get; set; }

        public List<Vehicle> ListofVehicles { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            ListofVehicles = new List<Vehicle>();
            ListofVehicles.Add(new Military() {Name = "Fiat", Number = "1", Mass = 500});
            ListofVehicles.Add(new Truck() { Name = "Skoda", Number = "3" , Mass = 700});
            ListofVehicles.Add(new Truck() { Name = "Porsche", Number = "100", Mass = 1000 });
            ListofVehicles.Add(new PersonalCar() { Name = "Mercedes", Number = "13", Mass = 800, SeatNumber = 5 });
        }

        public void OnGet()
        {
            int? count = this.HttpContext.Session.GetInt32("counter");

            if (count == null) { count = 0; }
            count++;
            this.HttpContext.Session.SetInt32("counter", count.Value);
            Count = count.Value;

        }
    }
}