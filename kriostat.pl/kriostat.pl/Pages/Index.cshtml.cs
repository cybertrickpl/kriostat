using kriostat.pl.DataBase;
using kriostat.pl.Warehouse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Serialization;

namespace kriostat.pl.Pages
{
    
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public int Count { get; set; }

        public List<Vehicle> ListofVehicles { get; set; }

        public List<Book> ListofBooks { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            ListofBooks = new List<Book>();
            ListofBooks.Add(new Book());
            ListofBooks.Add(new Book() { Title = "XXX", Author = "ABC", ISBN = "1" });

            Book book1 = new Book() { Title = "ABC", Author = "XYZ", ISBN = "2"} ;

            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Book));

            string? path = "D:\\Repository.txt";
            System.IO.FileStream file = System.IO.File.Create(path);

            foreach (var item in ListofBooks)
            {
                writer.Serialize(file, item);
            }

            file.Close();

             //ListofVehicles = new List<Vehicle>();
            //ListofVehicles.Add(new Military() {Name = "Fiat", Number = "1", Mass = 500});
            //ListofVehicles.Add(new Truck() { Name = "Skoda", Number = "3" , Mass = 700});
            //ListofVehicles.Add(new Truck() { Name = "Porsche", Number = "100", Mass = 1000 });
            //ListofVehicles.Add(new PersonalCar() { Name = "Mercedes", Number = "13", Mass = 800, SeatNumber = 5 });
        }

        //public void OnGet()
        //{
        //    int? count = this.HttpContext.Session.GetInt32("counter");

        //    if (count == null) { count = 0; }
        //    count++;
        //    this.HttpContext.Session.SetInt32("counter", count.Value);
        //    Count = count.Value;

        //}

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            return Page();
        }

    }
}